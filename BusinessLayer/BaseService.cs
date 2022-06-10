using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;
using AutoMapper;
using System.Collections;

namespace BusinessLayer
{
    public abstract class BaseService
    {
        protected ITransaction UnitOfWork { get; private set; }

        protected BaseService(ITransaction unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected virtual bool Validate(object model)
        {
            var modelValidator = new ModelValidator();
            if (!modelValidator.Validate(model))
            {
                throw new ModelValidationException($"{nameof(model)} is invalid", modelValidator.Errors);
            }
            else return true;
        }
    }
}