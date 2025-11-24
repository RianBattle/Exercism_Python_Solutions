public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as FacialFeatures;
        if (other is null)
        {
            return false;
        }

        return this.EyeColor == other.EyeColor
            && this.PhiltrumWidth == other.PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + EyeColor.GetHashCode();
            hash = hash * 23 + PhiltrumWidth.GetHashCode();
            return hash;
        }
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Identity;
        if (other is null)
        {
            return false;
        }

        return this.Email == other.Email
            && this.FacialFeatures.Equals(other.FacialFeatures);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash = hash * 23 + Email.GetHashCode();
            hash = hash * 23 + FacialFeatures.GetHashCode();
            return hash;
        }
    }
}

public class Authenticator
{
    private readonly HashSet<Identity> _identities = new();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Email == "admin@exerc.ism"
            && identity.FacialFeatures.EyeColor == "green"
            && identity.FacialFeatures.PhiltrumWidth == 0.9m;
    }

    public bool Register(Identity identity)
    {
        if (_identities.Any(x => x.GetHashCode() == identity.GetHashCode()))
        {
            return false;
        }
        return _identities.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        return _identities.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return identityA == identityB;
    }
}
