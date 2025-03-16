using api.Models;

namespace api.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetCommentsAsync();

    Task<Comment?> GetByIdAsync(int id);

    Task<Comment> CreateAsync(Comment commentModel);

    Task<Comment?> UpdateAsync(int id, Comment commentModel);

    Task<Comment?> DeleteAsync(int id);
}