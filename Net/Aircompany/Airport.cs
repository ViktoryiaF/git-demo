using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes;

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();
            for (int i=0; i < Planes.Count; i++)
            {
                if (Planes[i] is PassengerPlane)
                {
                    passengerPlanes.Add((PassengerPlane)Planes[i]);
                }
            }
            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();
            for (int i = 0; i < Planes.Count; i++)
            {
                if (Planes[i] is MilitaryPlane)
                {
                    militaryPlanes.Add((MilitaryPlane)Planes[i]);
                }
            }
            return militaryPlanes;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().Aggregate((w, x) => w.GetPassengersCapacity() > x.GetPassengersCapacity() ? w : x);             
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> transportMilitaryPlanes = new List<MilitaryPlane>();
            for (int i = 0; i < GetMilitaryPlanes().Count; i++)
            {
                if (GetMilitaryPlanes()[i].PlaneTypeIs() == MilitaryType.TRANSPORT)
                {
                    transportMilitaryPlanes.Add(GetMilitaryPlanes()[i]);
                }
            }
            return transportMilitaryPlanes;
        }

        public Airport SortByPlaneMaxFlightDistance()
        {
            return new Airport(Planes.OrderBy(w => w.GetPlaneMaxFlightDistance()));
        }

        public Airport SortByPlaneMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.GetPlaneMaxSpeed()));
        }

        public Airport SortByPlaneMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.GetPlaneMaxLoadCapacity()));
        }


        public IEnumerable<Plane> GetPlanes()
        {
            return Planes;
        }

        public override string ToString()
        {
            return "Airport{ planes=" + string.Join(", ", Planes.Select(x => x.GetPlaneModel())) +'}';
        }
    }
}
