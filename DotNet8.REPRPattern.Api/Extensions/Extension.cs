namespace DotNet8.REPRPattern.Api.Extensions;

public static class Extension
{
    public static Tbl_Blog ToEntity(this CreateBlogRequestDTO createBlogRequest)
    {
        return new Tbl_Blog
        {
            BlogTitle = createBlogRequest.BlogTitle,
            BlogAuthor = createBlogRequest.BlogAuthor,
            BlogContent = createBlogRequest.BlogContent,
        };
    }
}
