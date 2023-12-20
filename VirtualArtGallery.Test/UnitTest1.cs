using Microsoft.Data.SqlClient;
using VirtualArtGallery2.ArtgalleryRepository;
using VirtualArtGallery2;
using VirtualArtGallery2.Models;
using VirtualArtGallery2.myExceptions;

namespace VirtualArtGallery.Test;

public class Tests
{

    [Test]
    public void TestAddAndDeleteArtwork()
    {
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();
        Artwork artwork = new Artwork();
        artwork.ArtistId = 3;
        artwork.ArtworkId = 17;
        artwork.Description = "ABC";
        artwork.ImageURL = "ABC.COM";
        artwork.Medium = "BOOKS";
        artwork.Title = "ABCD";
        artwork.CreationDate = new DateTime(2023, 10, 12);
        bool ArtworkAddedStatus = intermediate.AddArtwork(conn,artwork);
        bool ArtworkAddedRemoved = intermediate.RemoveArtwork(conn,artwork.ArtworkId);

        Assert.That(ArtworkAddedStatus);
        Assert.That(ArtworkAddedRemoved);
    }

    [Test]
    public void TestAddAndDeleteArtist()
    {
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();
        Artist artist = new Artist();
        artist.ArtistID = 6;
        artist.Name = "Jeffrey Archer";
        artist.Nationality = "USA";
        artist.Website = "WWW.Jefrey.com";
        artist.ContactInformation = "868490";
        artist.Birthday= new DateTime(2023, 10, 12);
        artist.Biography = "Greatest Fiction Writer";

        bool ArtistAddedStatus = intermediate.AddArtist(conn, artist);
        bool ArtistRemovedStatus = intermediate.RemoveArtist(conn, artist.ArtistID);

        Assert.That(ArtistAddedStatus);
        Assert.That(ArtistRemovedStatus);
    }

    [Test]
    public void TestAddAndDeleteGallery()
    {
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();
        Gallery gallery = new Gallery();

        gallery.GalleryID = 5;
        gallery.ArtistID = 4;
        gallery.Description = "Academic Books";
        gallery.Location = "HYD";
        gallery.Name = "Wiley";
        gallery.OpeningHours = new DateTime(2023, 10, 12);

        bool GalleryAddedStatus = intermediate.AddGallery(conn, gallery);
        bool GalleryRemovedStatus = intermediate.RemoveGallery(conn, gallery.GalleryID);

        Assert.That(GalleryAddedStatus);
        Assert.That(GalleryRemovedStatus);
    }

    [Test]
    public void TestUpdateArtwork()
    {
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();

        Artwork artwork = new Artwork();
        artwork.ArtworkId = 18;
        artwork.ArtistId = 2;
        artwork.Title = "DD";
        artwork.Medium = "DD";
        artwork.ImageURL = "DD";
        artwork.Description = "DD";
        artwork.CreationDate= new DateTime(2023, 10, 12);

        bool UpdateStatus = intermediate.UpdateArtwork(conn, artwork);
        Assert.That(UpdateStatus);

    }

    [Test]
    public void TestUpdateArtist()
    {
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();

        Artist artist = new Artist();
        artist.ArtistID = 5;
        artist.Biography = "DD";
        artist.Birthday= new DateTime(2023, 10, 12);
        artist.ContactInformation = "88";
        artist.Name = "DD";
        artist.Nationality = "DD";
        artist.Website="DD";

        bool UpdateStatus = intermediate.UpdateArtist(conn, artist);
        Assert.That(UpdateStatus);

    }

    [Test]
    public void TestUpdateGallery()
    {
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();

        Gallery gallery = new Gallery();
        gallery.GalleryID = 35;
        gallery.ArtistID = 3;
        gallery.Description = "tt";
        gallery.Location = "tt";
        gallery.Name = "tt";
        gallery.OpeningHours= new DateTime(2023, 10, 12);

        bool UpdateStatus = intermediate.UpdateGallery(conn, gallery);
        Assert.That(UpdateStatus);

    }

    [Test]
    public void TestArtworkSearch()
    {
        List<Artwork> aList = new List<Artwork>();
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();

        aList = intermediate.SearchArtworkByID(conn,17);
        bool SearchStatus = (aList != null);
        Assert.That(SearchStatus);

    }

    [Test]
    public void TestArtistSearch()
    {
        List<Artist> aList = new List<Artist>();
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();

        aList = intermediate.SearchArtist(conn, 2);
        bool SearchStatus = (aList != null);
        Assert.That(SearchStatus);

    }

    [Test]
    public void TestGallerySearch()
    {
        List<Gallery> aList = new List<Gallery>();
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();

        aList = intermediate.SearchGallery(conn, 32);
        bool SearchStatus = (aList != null);
        Assert.That(SearchStatus);

    }

    [Test]
    public void UserProfileTest()
    {
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();
        var user = intermediate.UserProfile(conn, 21);
        int n = user.Count();
        bool UserStatus = (n == 1);
        Assert.That(UserStatus);
    }

    [Test]
    public void UserRegisterTest()
    {
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();
        Users users = new Users();
        users.UserID = 59;
        users.UserName = "joshua";
        users.Password = "password123";
        users.Email = "samson@gmail.com";
        users.FirstName = "Samson";
        users.LastName = "Joshua";
        users.ProfilePicture = "samson.jpg";
        users.DateOfBirth = new DateTime(2023, 10, 12);

        bool RegisterStatus = intermediate.Register(conn, users);

        string query = $"DELETE FROM USERS WHERE USERID={users.UserID}";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.ExecuteNonQuery();

        Assert.That(RegisterStatus);

    }

    [Test]
    public void DuplicateUserRegisterTest()
    {
        SqlConnection conn = DBConnection.Connect();
        IIntermediate intermediate = new Intermediate();
        Users users = new Users();
        users.UserID = 21;
        users.UserName = "samsungman";
        users.Password = "pragya";
        users.Email = "samson@gmail.com";
        users.FirstName = "Samson";
        users.LastName = "Joshua";
        users.ProfilePicture = "samson.jpg";
        users.DateOfBirth = new DateTime(2023, 10, 12);

        bool DuplicateUserStatus = intermediate.Register(conn, users);
        DuplicateUserStatus = !DuplicateUserStatus;
        Assert.That(DuplicateUserStatus);

    }

        


}
