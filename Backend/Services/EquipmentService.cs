using Backend.Database;
using Backend.Interfaces;
using Backend.Utilities;
using Core.Models.DTOs;
using Core.Models.Utilities;

namespace Backend.Services
{
    public class EquipmentService : Core.Interfaces.IEquipmentService
    {
        private readonly ILogger<EquipmentService> _logger;
        private readonly AppDbContext _context;
        private readonly IEquipmentEntityValidator _validator;

        public EquipmentService(ILogger<EquipmentService> logger,
            AppDbContext context,
            IEquipmentEntityValidator validator)
        {
            this._logger = logger;
            this._context = context;
            this._validator = validator;
        }

        /// <inheritdoc/>
        public async Task<EquipmentDTO> CreateEquipment(EquipmentDTO equipmentToCreate)
        {
            // Validate that the equipment is valid 
            var validation = _validator.ValidateEquipment(equipmentToCreate);

            if (!validation.IsValid)
            {
                throw new ValidationFailedException(validation.FailedValidations);
            }

            if (validation.Source is null)
            {
                throw new InvalidOperationException("Validation " +
                    "passed but source mapping failed for some reason.");
            }

            if (validation.Destination is null)
            {
                throw new InvalidOperationException("Validation " +
                    "passed but destination mapping failed for some reason.");
            }

            // Update in the database
            var addedValue = await _context.AddAsync(validation.Destination);
            await _context.SaveChangesAsync();

            // Return the object, with the id now; at this point, the object should not be null
            var addedEntity = addedValue.Entity;
            validation.Source.Id = addedEntity.Id;
            return validation.Source;
        }

        /// <inheritdoc/>
        public async Task<List<EquipmentDTO>> GetAllEquipment()
        {
            await Task.Run(() => Task.CompletedTask);
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<EquipmentDTO?> GetEquipmentByIdAsync(string id)
        {
            await Task.Run(() => Task.CompletedTask);
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<EquipmentDTO[]> GetEquipmentByNameAsync(string name)
        {
            await Task.Run(() => Task.CompletedTask);
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<EquipmentDTO> UpdateEquipment(EquipmentDTO equipmentToUpdateTo)
        {
            await Task.Run(() => Task.CompletedTask);
            throw new NotImplementedException();
        }
    }
}
