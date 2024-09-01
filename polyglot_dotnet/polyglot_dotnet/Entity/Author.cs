using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace polyglot_dotnet.Entity;

[Table("author")]
public class Author
{
    [Key]
    [Column("author_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuthorId { get; set; }

    [Column("first_name")]
    public required string FirstName { get; set; }
    
    [Column("last_name")]
    public required string LastName { get; set; }
}
