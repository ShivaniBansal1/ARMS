﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Arms.Application.Services.Users;
using Microsoft.AspNetCore.Http;
using Arms.Infrastructure;
using Arms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Arms.Domain.CustomEntities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arms.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ARMSEmployeeController : BaseController
    {
        private readonly IIdentityService _identityService;
        ArmsDbContext _context;
        public ARMSEmployeeController(IIdentityService identityService, ArmsDbContext armsContext)
        {
            _identityService = identityService;
            _context = armsContext;
        }

        [HttpGet]
        public IActionResult GetARMSEmployee()
        {
            List<ARMSEmployee> employees = _context.ARMSEmployee.ToList();
            try
            {
                if (employees != null)
                {
                    var response = new
                    {
                        success = true,
                        payload = new
                        {
                            data = employees,
                            message = "Employee Records Retrieved Successfully"
                        }

                    };
                    return StatusCode(200, response);
                }
                else
                {
                    var response = new
                    {
                        success = false,
                        payload = new
                        {
                            message = "Employee does not exist"
                        }

                    };
                    return StatusCode(404, response);
                }
            }
            catch (Exception e)
            {
                var response = new
                {
                    success = false,
                    payload = new
                    {
                        message = e.InnerException.Message
                    }

                };
                return StatusCode(500, response);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _context.ARMSEmployee.SingleOrDefault(c => c.Id == id);
            try
            {
                if (employee != null)
                {
                    var response = new
                    {
                        success = "true",
                        payload = new
                        {
                            data = employee,
                            message = "Employee Record Retrieved Successfully"
                        }

                    };
                    return StatusCode(200, response);

                }
                else
                {
                    var response = new
                    {
                        success = "true",
                        payload = new
                        {
                            message = "Employee Record with this ID does not exist"
                        }

                    };
                    return StatusCode(404, response);
                }
            }
            catch (Exception e)
            {
                var response = new
                {
                    success = false,
                    payload = new
                    {
                        message = e.InnerException.Message
                    }

                };
                return StatusCode(500, response);
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] CustomARMSEmployee customDTO)
        {
            try
            {
                var employeeObj = new ARMSEmployee
                {
                    Id = customDTO.Id,
                    Name = customDTO.Name,
                    Active = customDTO.Active,
                    IsSystemRole = customDTO.IsSystemRole,
                    SystemName = customDTO.SystemName,
                    DateCreated = customDTO.DateCreated,
                    DateModified = customDTO.DateModified,
                    RoleOrder = customDTO.RoleOrder,
                };
                _context.ARMSEmployee.Add(employeeObj);
                _context.SaveChanges();
                int id = employeeObj.Id;
                var response = new
                {
                    success = true,
                    payload = new
                    {
                        message = "Employee Record Created Successfully"
                    }

                };
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                var response = new
                {
                    success = false,
                    payload = new
                    {
                        message = e.InnerException.Message
                    }

                };
                return StatusCode(500, response);
            }
        }


        [HttpPatch("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] CustomARMSEmployee employeeObj)
        {
            var employee = _context.ARMSEmployee.SingleOrDefault(c => c.Id == id);
            try
            {
                if (employee != null)
                {
                    if (employeeObj.Name != null)
                    {
                        employee.Name = employeeObj.Name;
                    }
                    if (employeeObj.SystemName != null)
                    {
                        employee.SystemName = employeeObj.SystemName;
                    }
                    if (employeeObj.DateCreated != null)
                    {
                        employee.DateCreated = employeeObj.DateCreated;
                    }
                    if (employeeObj.DateModified != null)
                    {
                        employee.DateModified = employeeObj.DateModified;
                    }
                    _context.ARMSEmployee.Update(employee);
                    _context.SaveChanges();
                    var response = new
                    {
                        success = true,
                        payload = new
                        {
                            message = "Employee Record Updated Successfully"
                        }
                    };
                    return StatusCode(200, response);
                }
                else
                {
                    var response = new
                    {
                        success = false,
                        payload = new
                        {
                            message = "Employee does not exist"
                        }
                    };
                    return StatusCode(404, response);
                }
            }
            catch (Exception e)
            {
                var response = new
                {
                    success = false,
                    payload = new
                    {
                        message = e.InnerException.Message
                    }

                };
                return StatusCode(500, response);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.ARMSEmployee.SingleOrDefault(c => c.Id == id);
            try
            {
                if (employee != null)
                {
                    _context.ARMSEmployee.Remove(employee);
                    _context.SaveChanges();
                    var response = new
                    {
                        success = "true",
                        payload = new
                        {
                            message = "Employee Record Deleted Successfully"
                        }
                    };
                    return StatusCode(200, response);
                }
                else
                {
                    var response = new
                    {
                        success = "true",
                        payload = new
                        {
                            message = "Employee does not exist"
                        }
                    };
                    return StatusCode(404, response);
                }
            }
            catch (Exception e)
            {
                var response = new
                {
                    success = false,
                    payload = new
                    {
                        message = e.InnerException.Message
                    }

                };
                return StatusCode(500, response);
            }
        }


    }
}
