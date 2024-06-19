using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinBeat.Tech.Data.Domains;

public class DictionaryItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public int Code { get; set; }

    [Required] public string Value { get; set; }

    public static DictionaryItem Create(int code, string value) => new() { Code = code, Value = value };
}