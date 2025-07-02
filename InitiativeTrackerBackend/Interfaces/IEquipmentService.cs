using InitiativeTrackerBackend.Models.DTOs;
using System;

public interface IEquipmentService
{
    public Task<List<Equipment>> GetAllEquipment();
    public Task<Equipment> GetEquipment(string name);
    public Task<Equipment> CreateEquipment(Equipment equipment);
    public Task<Equipment> UpdateEquipment(string id, Equipment equipment);
}
