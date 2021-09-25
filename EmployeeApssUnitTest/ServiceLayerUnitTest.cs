using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer;
using Xunit;
using Assert = Xunit.Assert;

namespace EmployeeApssUnitTest
{
    [TestClass]
    public class ServiceLayerUnitTest
    {
        private  Mock<IService> _service;
        private List<EmployeeModel> _employeeModel;
        

        /// <summary>
        /// 
        /// </summary>
        public void Setup()
        {
            _service = new Mock<IService>();
            _employeeModel = GetListofEmployee();
        }

        public List<EmployeeModel> GetListofEmployee()
        {
            var employeeModels = new List<EmployeeModel>()
            {
                new EmployeeModel()
                {
                    ID= 1,
                    Name = "Jon",
                    Email = "jon_mani@conn.net",
                    Gender = "male",
                    Status = "active"

                },
                new EmployeeModel()
                {
                    ID= 2,
                    Name = "dannie",
                    Email = "dannie_mani@conn.net",
                    Gender = "male",
                    Status = "active"
                },
                new EmployeeModel()
                {
                    ID= 3,
                    Name = "maria",
                    Email = "maria_mani@conn.net",
                    Gender = "female",
                    Status = "active"
                }

            };

            return employeeModels;
        }


        [Fact]
        public void Get_User_Details_Successfully()
        {
            var employee = new EmployeeModel()
            {
                Name = "maria"
            };
            var urlBuilderMock = new Mock<IUrlBuilder>();

          var res =   urlBuilderMock.Setup(x => x.ConstructGetUrl(It.IsAny<EmployeeModel>())).Returns(Task.FromResult("maria"));
          res.Verifiable();

         var data = _service.Object.GetSpecificData("maria");

         Assert.NotNull(data);
         Assert.Equal(data.Count, _employeeModel.Count );

        }
    }
}
