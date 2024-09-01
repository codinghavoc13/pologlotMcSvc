using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace polyglot_dotnet.Entity;

[Table("book")]
public class Book
{
    [Key]
    [Column("book_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookId { get; set; }

    [Column("title")]
    public required string Title { get; set; }
    
    [Column("author_id")]
    public int AuthorId { get; set; }
    
    [Column("author_id")]
    [ForeignKey(nameof(AuthorId))]
    public required Author Author { get; set; }
}
