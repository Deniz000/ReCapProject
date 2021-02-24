using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorSevice
    {
        List<Color> GetAll();
        Color GetCarsByColorId(int id);
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}