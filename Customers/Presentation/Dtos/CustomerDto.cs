﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Dtos
{
    public class CustomerDto : BaseDto
    {
        public CustomerDto()
        {
            Contacts = new HashSet<ContactDto>();
            Departments = new HashSet<DepartmentDto>();
            Users = new HashSet<UserDto>();
        }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string AddressId { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(30)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Comments { get; set; }

        [Required]
        public CustomerType Type { get; set; }

        public int NumberOfSchools { get; set; }

        public AddressDto Address { get; set; }

        public ICollection<ContactDto> Contacts { get; set; }
        public ICollection<DepartmentDto> Departments { get; set; }
        public ICollection<UserDto> Users { get; set; }

        public Customer ToDataModel()
        {
            var dataModel= new Customer();
            dataModel.CustomerId = Guid.Parse(CustomerId);
            dataModel.Name = this.Name;
            dataModel.Email = this.Email;
            dataModel.Phone = this.Phone;
            dataModel.Comments = this.Comments;
            dataModel.Type = this.Type;
            dataModel.NumberOfSchools = this.NumberOfSchools;
            dataModel.ActionType = this.ActionType;

            dataModel.AddressId = Guid.Parse(this.AddressId);
            dataModel.Address = this.Address.ToDataModel();

            return dataModel;
        }

        public void FromDataModel(Customer dataModel)
        {
            CustomerId = dataModel.CustomerId.ToString();
            Name = dataModel.Name;
            Email = dataModel.Email;
            Phone = dataModel.Phone;
            Comments = dataModel.Comments;
            Type = dataModel.Type;
            NumberOfSchools = dataModel.NumberOfSchools;
            AddressId = dataModel.AddressId.ToString();
            Address = new AddressDto();
            Address.FromDataModel(dataModel.Address);
        }
    }
}
