using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class NamedPoint : IComparable<NamedPoint>
    {
        /// <summary>
        /// The name
        /// </summary>
        private readonly string name;
        /// <summary>
        /// The coordinates
        /// </summary>
        private readonly float x, y;
        /// <summary>
        /// The character used as a field delimiter when converting to a string
        /// </summary>
        private const char FIELD_DELIM = ',';

        /// <summary>
        /// Normal constructor
        /// </summary>
        /// <param name="name">The name of the item</param>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        public NamedPoint(string name, float x, float y)
        {
            if (name.Contains(FIELD_DELIM))
            {
                throw new ArgumentException(String.Format("Name cannot contain {0}", FIELD_DELIM));
            }
            this.name = name;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Parse will create a new obect from a string record.
        /// This is the opposite of ToCsv().
        /// </summary>
        /// <param name="record">The point in csv format</param>
        public static NamedPoint Parse(string record)
        {
            string[] parts = record.Split(FIELD_DELIM);
            if (parts.Length != 3)
            {
                throw new ArgumentException(String.Format("invalid record format: {0}", record));
            }
            string name = parts[0].Trim();
            float x = float.Parse(parts[1]);
            float y = float.Parse(parts[2]);
            return new NamedPoint(name, x, y);
        }

        /// <summary>
        /// Format the record as a string, so we can save it in a text file
        /// </summary>
        /// <returns>The item formatted as a string</returns>
        public string ToCsv()
        {
            return String.Format("{1}{0}{2}{0}{3}", FIELD_DELIM, this.name, this.x, this.y);
        }

        /// <summary>
        /// Format the record as a string, for human readable display
        /// </summary>
        /// <returns>The item formatted as a string</returns>
        public override string ToString()
        {
            return String.Format("Point {0} at ({1},{2})", this.name, this.x, this.y);
        }

        /// <summary>
        /// The name of the point.
        /// Because a point is more than just a number.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// The x coordinate
        /// </summary>
        /// <returns></returns>
        public float GetX()
        {
            return x;
        }

        /// <summary>
        /// The y coordinate
        /// </summary>
        /// <returns></returns>
        public float GetY()
        {
            return y;
        }

        /// <summary>
        /// The distance from the origin to this point.
        /// </summary>
        /// <returns>the distance</returns>
        public float GetMagnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Implement the IComparable interface.
        /// Sort by name.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(NamedPoint other)
        {
            // sort by name
            return this.GetName().CompareTo(other.GetName());
            // sort by distance from origin
            // return this.GetMagnitude().CompareTo(other.GetMagnitude());
        }
    }
}
