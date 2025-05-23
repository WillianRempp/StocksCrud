using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDBContext _context;
    public CommentRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Comment> CreateAsync(Comment commentModel)
    {
        await _context.Comment.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
        var commentModel = await _context.Comment.FirstOrDefaultAsync(x => x.Id == id);

        if(commentModel == null){
            return null;
        }
        _context.Comment.Remove(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        var comment = await _context.Comment.FirstOrDefaultAsync(x => x.Id == id);
        if (comment == null)
        {
            return null;
        }

        return comment;
    }

    public async Task<List<Comment>> GetCommentsAsync()
    {
        return await _context.Comment.ToListAsync();
    }

    public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
    {
        var existingComment = await _context.Comment.FindAsync(id);

        if(existingComment == null){
            return null;
        }

        existingComment.Title = commentModel.Title;
        existingComment.Content = commentModel.Content;

        await _context.SaveChangesAsync();
        return existingComment;
    }
}