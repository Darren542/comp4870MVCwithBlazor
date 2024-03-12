using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeamPlayersMVC.Models;

public class Player
{
    public int PlayerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Position { get; set; }
    public int? JerseyNumber { get; set; }

    [Required]
    public string? TeamName { get; set; }
    

    [ForeignKey("TeamName")]
    public Team? Team { get; set; }
}
