using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private ICarImageDal _carImageDAL;

       

        public CarImageManager(ICarImageDal carImageDAL)
        {
            _carImageDAL = carImageDAL;
        }
       

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var imageCount = _carImageDAL.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult("One car must have 5 or less images");
            }

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDAL.Add(carImage);
            return new SuccessResult("Car image added");
        }
        
        
        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDAL.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            FileHelper.Delete(image.ImagePath);
            _carImageDAL.Delete(carImage);
            return new SuccessResult("Image was deleted successfully");
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var isImage = _carImageDAL.Get(c => c.Id == carImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDAL.Update(carImage);
            return new SuccessResult("Car image updated");
        }
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDAL.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDAL.GetAll());
        }
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }


        //business rules

        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDAL.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult("");
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carImageDAL.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDAL.GetAll(p => p.CarId == id).ToList());
        }
        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
    

