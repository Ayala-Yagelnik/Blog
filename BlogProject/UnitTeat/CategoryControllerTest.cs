using BlogProject.Controllers;
using BlogProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class CategoryControllerTest
    {
        [Fact]
        public void GetAll_ReturnListOfCategories()
        {
            var controller = new CategoryController();
            var result = controller.Get();
            Assert.IsType<ActionResult<List<Category>>>(result);

        }
        [Fact]
        public void GetById_ReturnCategory()
        {
            int id = 1;
            var controller = new CategoryController();
            var result = controller.Get(id);
            Assert.IsType<ActionResult<Category>>(result);

        }
        [Fact]
        public void Post_ReturnTrue()
        {

            Category obj = new Category {Id= 2, Name="Computer programming",ParentID= 1,Description= "all about how to bnkjk...." };
            var controller = new CategoryController();
            bool result = controller.Post(obj).Value;
            Assert.True(result);
        }

        [Fact]
        public void Put_ReturnFalse()
        {
            var id = 5;
            Category obj = new Category { Id = 2, Name = "Computer programming", ParentID = 1, Description = "all about how to bnkjk...." };
            var controller = new CategoryController();
            bool result = controller.Put(id, obj).Value;
            Assert.False(result);
        }
 
    }
}
