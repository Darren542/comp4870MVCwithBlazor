using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamPlayersMVC.Data;
using TeamPlayersMVC.Models;

namespace TeamPlayersMVC.Data;

public class PlayerService
{
    private ApplicationDbContext _context;
    public PlayerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Player>> GetPlayersAsync()
    {
        return await  _context.Players.ToListAsync();
    }

    public async Task<Player?> GetPlayerByIdAsync(int id)
    {
        return await _context.Players.FindAsync(id) ?? null;
    }

    public async Task<Player?> InsertPlayerAsync(Player Player)
    {
        _context.Players.Add(Player);
        await _context!.SaveChangesAsync();

        return Player;
    }

    public async Task<Player> UpdatePlayerAsync(int id, Player s)
    {
        var Player = await _context.Players!.FindAsync(id);

        if (Player == null)
            return null!;

        Player.FirstName = s.FirstName;
        Player.LastName = s.LastName;
        Player.Position = s.Position;
        Player.TeamName = s.TeamName;

        _context.Players.Update(Player);
        await _context.SaveChangesAsync();

        return Player!;
    }

    public async Task<Player> DeletePlayerAsync(int id)
    {
        var Player = await _context.Players!.FindAsync(id);

        if (Player == null)
            return null!;

        _context.Players.Remove(Player);
        await _context.SaveChangesAsync();

        return Player!;
    }

    private bool PlayerExists(int id)
    {
        return _context.Players!.Any(e => e.PlayerId == id);
    }
}