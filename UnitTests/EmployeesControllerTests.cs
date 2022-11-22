using CrudApplication.Controllers;
using CrudApplication.Data;
using FakeItEasy;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using NUnit;
using CrudApplication.Models;

namespace UnitTests
{

    public class EmployeesControllerTests
    {
        public AddEmployeeViewModel _employeesController;

        [SetUp]
        //public void Setup()
        //{
        //    _employeesController = new EmployeesController();
        //}

        [Test]
        public void Index_Works()
        {

            // Arrange

            _employeesController = new AddEmployeeViewModel()
            {

                Name = "Daniel",
                Email = "Danielikechukwu@gmail.com",
                Salary = 2000000,
                DateOfBirth = Convert.ToDateTime("11/10/20"),
                Department = "HR",
            };
            

            // Act


            // Assert
        }
    }
}