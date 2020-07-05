using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KodluyoruzBootcampEFCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace KodluyoruzBootcampEFCore.Services
{
    public class PostService : IGeneralService<Post>
    {
        private readonly IUnitOfWork<BloggingContext> _unitOfWork;

        public PostService(IUnitOfWork<BloggingContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> Get()
        {
            return await _unitOfWork.GetRepository<Post>().GetAllAsync();
        }


        public async Task<Post> Add([FromBody] Post entity)
        {
            Post post = await _unitOfWork.GetRepository<Post>().AddAsync(new Post
            {
                PostId = entity.PostId,
                Title = entity.Title,
                BlogId = entity.BlogId,
                Blog = entity.Blog,
                Content = entity.Content
            });

            return post;
        }


        public async Task<bool> Create([FromBody] Post entity)
        {
            Post post = await _unitOfWork.GetRepository<Post>().AddAsync(new Post
            {
                PostId = entity.PostId,
                Title = entity.Title,
                BlogId = entity.BlogId,
                Blog = entity.Blog,
                Content = entity.Content
            });

            return post != null && post.PostId != 0;
        }


        public async Task<bool> IsExists(string name)
            => await _unitOfWork.GetRepository<Post>().FindAsync(x => string.Equals(x.Title, name, StringComparison.CurrentCultureIgnoreCase)) != null;

        public async Task<bool> IsExists(int id, string name) =>
            await _unitOfWork.GetRepository<Post>().FindAsync(x => x.PostId != id && string.Equals(x.Title, name, StringComparison.CurrentCultureIgnoreCase)) != null;



        public async Task<IActionResult> Delete(Post entity)
        {
            await _unitOfWork.GetRepository<Post>().DeleteAsync(entity);
            await _unitOfWork.Commit();
            return (IActionResult)entity;
        }

        

        public Task<IActionResult> Update(int id, [FromBody] Post entity)
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGeneralService<Post>.Update(int id, Post entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        


    }
}
