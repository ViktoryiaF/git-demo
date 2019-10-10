using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        public string planeModel;
        public int planeMaxSpeed;
        public int planeMaxFlightDistance;
        public int planeMaxLoadCapacity;

        public Plane(string planeModel, int planeMaxSpeed, int planeMaxFlightDistance, int planeMaxLoadCapacity)
        {
            this.planeModel = planeModel;
            this.planeMaxSpeed = planeMaxSpeed;
            this.planeMaxFlightDistance = planeMaxFlightDistance;
            this.planeMaxLoadCapacity = planeMaxLoadCapacity;
        }

        public string GetPlaneModel()
        {
            return this.planeModel;
        }

        public int GetPlaneMaxSpeed()
        {
            return this.planeMaxSpeed;
        }

        public int GetPlaneMaxFlightDistance()
        {
            return this.planeMaxFlightDistance;
        }

        public int GetPlaneMaxLoadCapacity()
        {
            return this.planeMaxLoadCapacity;
        }

        public override string ToString()
        {
            return "Plane { planeModel = " + this.planeModel + 
                ", planMaxSpeed = " + this.planeMaxSpeed +
                ", planeMaxFlightDistance = " + this.planeMaxFlightDistance +
                ", planeMaxLoadCapacity = " + this.planeMaxLoadCapacity + '}';
        }

        public override bool Equals(object objectToCompare)
        {
            return (objectToCompare as Plane) != null &&
                   planeModel == (objectToCompare as Plane).planeModel &&
                   planeMaxSpeed == (objectToCompare as Plane).planeMaxSpeed &&
                   planeMaxFlightDistance == (objectToCompare as Plane).planeMaxFlightDistance &&
                   planeMaxLoadCapacity == (objectToCompare as Plane).planeMaxLoadCapacity;
        }

        public override int GetHashCode()
        {
            var hashCode = -1043886837;
            return (((hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(planeModel))
            * hashCode * -1521134295 + planeMaxSpeed.GetHashCode())
            * hashCode * -1521134295 + planeMaxFlightDistance.GetHashCode())
            * hashCode * -1521134295 + planeMaxLoadCapacity.GetHashCode();
            
        }        

    }
}
