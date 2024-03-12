using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamPlayersMVC.Data;
using TeamPlayersMVC.Models;

namespace TeamPlayersMVC.Data;

public class TeamService
{
    private ApplicationDbContext _context;
    public TeamService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Team>> GetTeamsAsync()
    {
        return await  _context.Teams.ToListAsync();
    }

    public async Task<Team?> GetTeamByIdAsync(int id)
    {
        return await _context.Teams.FindAsync(id) ?? null;
    }

}