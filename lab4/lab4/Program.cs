using System;

struct Vector3D
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }

    
    public Vector3D(double x, double y, double z)
    {
        try
        {
            if (x < 0 || y < 0 || z < 0)
                throw new ArgumentException("Coordinates cannot be negative.");

            X = x;
            Y = y;
            Z = z;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            X = Y = Z = 0; 
        }
        finally
        {
            Console.WriteLine("Constructor execution completed.");
        }
    }

    
    public static Vector3D operator +(Vector3D v1, Vector3D v2) =>
        new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

    
    public static Vector3D operator -(Vector3D v1, Vector3D v2) =>
        new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

    
    public static Vector3D operator *(Vector3D v, double scalar)
    {
        try
        {
            if (scalar == 0)
                throw new ArgumentException("Scalar cannot be zero.");
            return new Vector3D(v.X * scalar, v.Y * scalar, v.Z * scalar);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new Vector3D();
        }
        finally
        {
            Console.WriteLine("Scalar multiplication executed.");
        }
    }

    
    public double Length() => Math.Sqrt(X * X + Y * Y + Z * Z);

    
    public override string ToString() => $"Vector3D({X}, {Y}, {Z})";

    
    public override bool Equals(object obj) =>
        obj is Vector3D v && X == v.X && Y == v.Y && Z == v.Z;

    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
}

class Program
{
    static void Main()
    {
        
        var vectors = ReadVectorArray();

        
        foreach (var vector in vectors)
            PrintVector(vector);

        
        SortVectors(ref vectors);
        Console.WriteLine("Sorted vectors:");
        foreach (var vector in vectors)
            PrintVector(vector);

        
        Console.WriteLine("Modifying first vector...");
        ModifyVector(ref vectors[0]);
        PrintVector(vectors[0]);

        
        GetMinMaxLengths(vectors, out double minLength, out double maxLength);
        Console.WriteLine($"Min Length: {minLength}, Max Length: {maxLength}");
    }

    
    static Vector3D[] ReadVectorArray()
    {
        Console.Write("Enter the number of vectors: ");
        int n = int.Parse(Console.ReadLine() ?? "0");
        Vector3D[] vectors = new Vector3D[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter coordinates for vector {i + 1}:");
            Console.Write("X: ");
            double x = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Y: ");
            double y = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Z: ");
            double z = double.Parse(Console.ReadLine() ?? "0");
            vectors[i] = new Vector3D(x, y, z);
        }

        return vectors;
    }

    
    static void PrintVector(Vector3D vector)
    {
        Console.WriteLine(vector);
    }

    
    static void SortVectors(ref Vector3D[] vectors)
    {
        Array.Sort(vectors, (v1, v2) => v1.Length().CompareTo(v2.Length()));
    }

    
    static void ModifyVector(ref Vector3D vector)
    {
        Console.Write("Enter new X: ");
        double x = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Enter new Y: ");
        double y = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Enter new Z: ");
        double z = double.Parse(Console.ReadLine() ?? "0");

        vector = new Vector3D(x, y, z);
    }

    
    static void GetMinMaxLengths(Vector3D[] vectors, out double minLength, out double maxLength)
    {
        minLength = double.MaxValue;
        maxLength = double.MinValue;

        foreach (var vector in vectors)
        {
            double length = vector.Length();
            if (length < minLength) minLength = length;
            if (length > maxLength) maxLength = length;
        }
    }
}
