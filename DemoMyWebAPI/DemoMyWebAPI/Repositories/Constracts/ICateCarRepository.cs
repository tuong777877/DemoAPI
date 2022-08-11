﻿using DemoMyWebAPI.Models;

namespace DemoMyWebAPI.Repository.Constracts
{
    public interface ICateCarRepository
    {
        List<CateCarVM> GetAll();

        CateCarVM GetById(int id);

        CateCarVM Add(CateCarModel model);

        void Update(CateCarVM cateacarVM);

        void Delete(int id);
    }
}