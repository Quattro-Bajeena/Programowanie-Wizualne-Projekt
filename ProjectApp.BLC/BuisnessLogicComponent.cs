﻿using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.Interfaces;
using System.Reflection;

namespace OleszekMowinski.ProjectApp.BLC
{
    //Buisness logic component
    public class BuisnessLogicComponent
    {
        private readonly IDAO dao = null!;

        public BuisnessLogicComponent(string libraryName)
        {
            Type? typeToCreate = null;
            var assembly = Assembly.UnsafeLoadFrom(libraryName);

            foreach ( var type in assembly.GetTypes())
            {
                if(type.IsAssignableTo(typeof(IDAO)))
                {
                    typeToCreate = type;
                    break;
                }
            }
            dao = (IDAO)Activator.CreateInstance(typeToCreate, null);
        }

        public IEnumerable<IAirplane> GetAirplanes() => dao.GetAirplanes();
        public IEnumerable<IManufacturer> GetManufacturer() => dao.GetManufacturer();
        public IAirplane CreateNewAirplane(string name, DateTime introduction, int weight, AirplaneStatus status, Guid manufacturerId) => dao.CreateNewAirplane(name, introduction, weight, status, manufacturerId);
        public IManufacturer CreateNewManufacturer(string name, DateTime founded, string headquaters, string president) => dao.CreateNewManufacturer(name, founded, headquaters, president);
        public IEnumerable<IAirplane> GetFilteredAirplanes(AirplaneFilter filter) => dao.GetFilteredAirplanes(filter);
        public void DeleteAirplane(Guid id) => dao.DeleteAirplane(id);
        public void DeleteProducera(Guid id) => dao.DeleteManufacturer(id);
    }
}