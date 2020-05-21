﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTCSDL.Common.Rsp;
using LTCSDLBTL.BLL;
using LTCSDLBTL.Common.Req;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTCSDLBTL.WebBanHoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductSvc _svc;
        public ProductsController()
        {
            _svc = new ProductSvc();
        }
        [HttpPost("get-all")]
        public IActionResult getAllProduct()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        [HttpPost("search-products")]
        public IActionResult SearchProducts([FromBody]SearchProductReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchProduct(req.Keyword, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }
        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody]ProductReq req)
        {
            var res = _svc.CreateProduct(req);
            return Ok(res);
        }
        [HttpPost("update-product")]
        public IActionResult UpdateProduct([FromBody]ProductReq req)
        {
            var res = _svc.UpdateProduct(req);
            return Ok(res);
        }
    }
}