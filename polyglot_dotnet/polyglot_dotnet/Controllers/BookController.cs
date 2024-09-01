using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Npgsql;
using polyglot_dotnet.Data;
using polyglot_dotnet.Entity;

//include the semi-colon at the end of the namespace declaration or include the two commented curly brackets
namespace polyglot_dotnet.Controllers;
// {
/*putting controller in square brackets like this will automatically set the path
to the name of the controller (BookController) minus the Controller part of the name,
so Book. "polyglot/[controller]" === "polyglot/book"
*/
[Route("polyglot/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly DbConn conn;

    public BookController(DbConn conn)
    {
        this.conn = conn;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        IEnumerable<Book> bookResp = await conn.Books.ToListAsync();
        foreach (Book book in bookResp)
        {
            Author? author = await conn.Authors.FindAsync(book.AuthorId);
            if (author != null)
            {
                book.Author = author;
            }
        }
        // string jsonResp = JsonConvert.SerializeObject(bookResp);
        // return Ok(jsonResp);
        return Ok(bookResp);
    }
}
// }
