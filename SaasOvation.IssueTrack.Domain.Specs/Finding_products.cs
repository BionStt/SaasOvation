﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaasOvation.IssueTrack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace SaasOvation.IssueTrack.Domain.Specs
{
    [TestClass]
    public class Finding_products
    {
        IQueryProducts SUT;

        ProductId a_product_id = new ProductId(Guid.NewGuid());
        TenantId a_tenant_id = new TenantId(Guid.NewGuid());
        string a_product_name = "Zee product";
        string a_product_description = "Zee description";

        ProductId another_product_id = new ProductId(Guid.NewGuid());
        TenantId another_tenant_id = new TenantId(Guid.NewGuid());
        string another_product_name = "Another product";
        string another_product_description = "Another description";


        [TestInitialize]
        public void Init()
        {
            var state = new ProductState();    
            SUT= state;

            state.ProductRegistered(a_product_id, a_tenant_id, a_product_name, a_product_description);
            state.ProductRegistered(another_product_id, another_tenant_id, another_product_name, another_product_description);
        }

        

        [TestMethod]
        public void Get_a_product_by_id()
        {
            var result = SUT.GetById(a_product_id);
            result.Id.ShouldBe(a_product_id);
            result.TenantId.ShouldBe(a_tenant_id);
        }

        [TestMethod]
        public void Get_a_product_by_id_that_does_not_exist()
        {
            var a_non_existing_product = new ProductId(Guid.NewGuid());
            var result = SUT.GetById(a_non_existing_product);
            result.ShouldBe(null);
        }

    }
}
