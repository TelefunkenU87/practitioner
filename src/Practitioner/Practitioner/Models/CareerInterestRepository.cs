using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Models
{
    public class CareerInterestRepository : ICareerInterestRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connString;
        public CareerInterestRepository(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("DefaultConnection");
        }
        public CareerInterest AddCareerInterest(CareerInterest addCareerInterest)
        {
            var procedure = "spAddCareerInterest";
            var parameters = new
            {
                @EmployeeId = addCareerInterest.EmployeeId,
                @Role = addCareerInterest.Role,
                @Other = addCareerInterest.Other,
                @Office = addCareerInterest.Office,
                @Industry = addCareerInterest.Industry,
                @Sector = addCareerInterest.Sector,
                @Comment = addCareerInterest.Comment
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                var executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return addCareerInterest;
        }

        public int DeleteCareerInterest(int careerInterestId)
        {
            var procedure = "spDeleteCareerInterest";
            var parameters = new { @CareerInterestId = careerInterestId };
            int executedRows = 0;

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                executedRows = conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return executedRows;
        }

        public List<CareerInterest> GetCareerInterestByEmployeeId(int employeeId)
        {
            var procedure = "spGetCareerInterestByEmployeeId";
            var parameter = new { @EmployeeId = employeeId };
            var careerInterests = new List<CareerInterest>();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                careerInterests = conn.Query<CareerInterest>(procedure, parameter, commandType: CommandType.StoredProcedure).ToList();
            }
            return careerInterests;
        }

        public CareerInterest GetCareerInterestById(int careerInterestId)
        {
            var procedure = "spGetCareerInterestById";
            var parameter = new { @CareerInterestId = careerInterestId };
            var careerInterest = new CareerInterest();

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                careerInterest = conn.QueryFirstOrDefault<CareerInterest>(procedure, parameter, commandType: CommandType.StoredProcedure);
            }
            return careerInterest;
        }

        public CareerInterest UpdateCareerInterest(CareerInterest updatedCareerInterest)
        {
            var procedure = "spUpdateCareerInterest";
            var parameters = new
            {
                @CareerInterestId = updatedCareerInterest.CareerInterestId,
                @EmployeeId = updatedCareerInterest.EmployeeId,
                @Role = updatedCareerInterest.Role,
                @Other = updatedCareerInterest.Other,
                @Office = updatedCareerInterest.Office,
                @Industry = updatedCareerInterest.Industry,
                @Sector = updatedCareerInterest.Sector,
                @Comment = updatedCareerInterest.Comment
            };

            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return updatedCareerInterest;
        }
    }
}
