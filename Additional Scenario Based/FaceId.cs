

using System;
using System.Collections.Generic;

namespace Security.Authentication
{
    // ============================
    // FacialFeatures (Value Object)
    // ============================
    public sealed class FacialFeatures : IEquatable<FacialFeatures>
    {
        public string EyeColor { get; }
        public decimal PhiltrumWidth { get; }

        public FacialFeatures(string eyeColor, decimal philtrumWidth)
        {
            EyeColor = eyeColor;
            PhiltrumWidth = philtrumWidth;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as FacialFeatures);
        }

        public bool Equals(FacialFeatures other)
        {
            if (other is null)
                return false;

            return EyeColor == other.EyeColor &&
                   PhiltrumWidth == other.PhiltrumWidth;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EyeColor, PhiltrumWidth);
        }
    }

    // ============================
    // Identity (Composite Equality)
    // ============================
    public sealed class Identity : IEquatable<Identity>
    {
        public string Email { get; }
        public FacialFeatures FacialFeatures { get; }

        public Identity(string email, FacialFeatures facialFeatures)
        {
            Email = email;
            FacialFeatures = facialFeatures;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as Identity);
        }

        public bool Equals(Identity other)
        {
            if (other is null)
                return false;

            return Email == other.Email &&
                   FacialFeatures.Equals(other.FacialFeatures);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email, FacialFeatures);
        }
    }

    // ============================
    // Authenticator (Business Logic)
    // ============================
    public class Authenticator
    {
        private readonly HashSet<Identity> _registeredIdentities =
            new HashSet<Identity>();

        private static readonly Identity _admin =
            new Identity(
                "admin@exerc.ism",
                new FacialFeatures("green", 0.9m)
            );

        public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
        {
            return faceA.Equals(faceB);
        }

        public bool Register(Identity identity)
        {
            return _registeredIdentities.Add(identity);
        }

        public bool IsRegistered(Identity identity)
        {
            return _registeredIdentities.Contains(identity);
        }

        public bool IsAdmin(Identity identity)
        {
            return _admin.Equals(identity);
        }

        public static bool AreSameObject(Identity identityA, Identity identityB)
        {
            return ReferenceEquals(identityA, identityB);
        }
    }

    // ============================
    // Program (Main Method)
    // ============================
    class Program
    {
        static void Main()
        {
            var authenticator = new Authenticator();

            // Face comparison
            Console.WriteLine(
                Authenticator.AreSameFace(
                    new FacialFeatures("green", 0.9m),
                    new FacialFeatures("green", 0.9m)
                )
            ); // True

            // Admin authentication
            Console.WriteLine(
                authenticator.IsAdmin(
                    new Identity("admin@exerc.ism",
                    new FacialFeatures("green", 0.9m))
                )
            ); // True

            // Registration
            var user = new Identity(
                "tunde@thecompetition.com",
                new FacialFeatures("blue", 0.9m)
            );

            Console.WriteLine(authenticator.Register(user)); // True
            Console.WriteLine(authenticator.IsRegistered(user)); // True
            Console.WriteLine(authenticator.Register(user)); // False

            // Reference vs Value equality
            var identityA = new Identity(
                "alice@thecompetition.com",
                new FacialFeatures("blue", 0.9m)
            );

            var identityB = identityA;

            var identityC = new Identity(
                "alice@thecompetition.com",
                new FacialFeatures("blue", 0.9m)
            );

            Console.WriteLine(
                Authenticator.AreSameObject(identityA, identityB)
            ); // True

            Console.WriteLine(
                Authenticator.AreSameObject(identityA, identityC)
            ); // False
        }
    }
}
