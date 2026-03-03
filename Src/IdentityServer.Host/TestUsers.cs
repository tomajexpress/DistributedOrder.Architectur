using Duende.IdentityModel;
using Duende.IdentityServer.Test;
using System.Security.Claims;

namespace IdentityServer.Host;

public static class TestUsers
{
    public static List<TestUser> Users =>
        [
            // Benutzer 1: Senior Entwickler (Mit erweiterten Rechten)
            new TestUser
            {
                SubjectId = "1",
                Username = "alice",
                Password = "alice",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Alice Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Alice"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "alice@DistributedOrder.Architectur.local"),
                    new Claim(JwtClaimTypes.Role, "SeniorDeveloper") // Die Rolle für spätere [Authorize] Attribute
                }
            },
            
            // Benutzer 2: Regulärer Benutzer / Neues Teammitglied
            new TestUser
            {
                SubjectId = "2",
                Username = "bob",
                Password = "bob",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Bob Jones"),
                    new Claim(JwtClaimTypes.GivenName, "Bob"),
                    new Claim(JwtClaimTypes.FamilyName, "Jones"),
                    new Claim(JwtClaimTypes.Email, "bob@DistributedOrder.Architectur.local"),
                    new Claim(JwtClaimTypes.Role, "User")
                }
            }
        ];
}