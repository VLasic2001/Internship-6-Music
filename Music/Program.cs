using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Music.Models;

namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
                "Data Source = (LocalDb)\\MSSQLLocalDB;Initial Catalog = MusicDatabase;Integrated Security = true;MultipleActiveResultSets = true;";

            var artistList = new SqlConnection(connectionString).Query<Artist>("Select * from Artists").ToList();

            var albumList = new SqlConnection(connectionString).Query<Album>("Select * from Albums").ToList();

            var songList = new SqlConnection(connectionString).Query<Song>("Select * from Songs").ToList();

            var albumSongList = new SqlConnection(connectionString).Query<Album_Song>("Select * from Albums_Songs").ToList();

            Link(artistList, albumList, songList, albumSongList);

            //1
            ArtistsOrderedByName(artistList);
            //2
            ArtistsOfCertainNationality(artistList);
            //3
            AlbumsGroupedByYearOfRelease(albumList);
            //4
            Console.WriteLine("Enter text you want to check for in album names: ");
            var inputText = Console.ReadLine();
            AlbumsThatContainGivenText(albumList, inputText);
            //5
            AlbumsWithTotalDuration(albumList);
            //6
            Console.WriteLine("Enter name of the song you want to check for in albums: ");
            var inputSongName = Console.ReadLine();
            AlbumsThatContainCertainSong(albumList, inputSongName);
            //7
            SongsOfArtistAfterCertainYear(artistList);
            //Extra
            AlbumsOrderedByNameAndReleasedAfterCertainYear(albumList);
        }

        public static void Link(List<Artist> artists, List<Album> albums, List<Song> songs, List<Album_Song> albumSongs)
        {
            foreach (var artist in artists)
            {
                foreach (var album in albums)
                {
                    if (album.ArtistId != artist.ArtistId) continue;
                    artist.AddAlbumToArtist(album);
                    album.Artist = artist;
                }
            }

            foreach (var albumSong in albumSongs)
            {
                foreach (var album in albums)
                {
                    if (albumSong.AlbumId != album.AlbumId) continue;
                    foreach (var song in songs)
                    {
                        if (song.SongId != albumSong.SongId) continue;
                        album.AddSongToAlbum(song);
                        song.AddAlbumToSong(album);
                    }
                }
            }
        }

        public static void ArtistsOrderedByName(List<Artist> artists)
        {
            Console.WriteLine("Artists ordered by name: ");
            var sortedArtists = artists.OrderBy(artist => artist.Name).ToList();
            foreach (var artist in sortedArtists)
            {
                Console.WriteLine(artist.Name);
            }

            Console.WriteLine();
        }

        public static void ArtistsOfCertainNationality(List<Artist> artists)
        {
            var artistsOfCertainNationality = artists.Where(artist => artist.Nationality == "German");
            Console.WriteLine("All German artists: ");
            foreach (var artist in artistsOfCertainNationality)
            {
                Console.WriteLine(artist.Name);
            }

            Console.WriteLine();
        }

        public static void AlbumsGroupedByYearOfRelease(List<Album> albums)
        {
            var groupedAlbumYears = albums.GroupBy(album => album.YearOfRelease).OrderBy(album => album.Key);
            foreach (var groupedAlbumYear in groupedAlbumYears)
            {
                Console.WriteLine(groupedAlbumYear.Key);
                foreach (var album in albums)
                {
                    if (album.YearOfRelease == groupedAlbumYear.Key)
                        Console.WriteLine($"    {album.Name} - {album.Artist.Name}");
                }
            }

            Console.WriteLine();
        }

        public static void AlbumsThatContainGivenText(List<Album> albums, string text)
        {
            Console.WriteLine($"Albums that contain '{text}' are: ");
            var doAnyAlbumsWithTextExist = false;
            foreach (var album in albums)
            {
                if (!album.Name.ToLower().Contains(text.ToLower())) continue;
                Console.WriteLine(album.Name);
                doAnyAlbumsWithTextExist = true;
            }
            if (doAnyAlbumsWithTextExist)
                Console.WriteLine();
            else
            {
                Console.WriteLine($"No albums exist which contain '{text}'");
                Console.WriteLine();
            }
        }

        public static void AlbumsWithTotalDuration(List<Album> albums)
        {
            Console.WriteLine("All albums and their total duration:");
            foreach (var album in albums)
            {
                var totalDuration = album.Songs.Sum(song => song.DurationInSeconds);

                Console.WriteLine($"{album.Name} - {TimeSpan.FromSeconds(totalDuration)}");
            }

            Console.WriteLine();
        }

        public static void AlbumsThatContainCertainSong(List<Album> albums, string songName)
        {
            var doAnyAlbumsWithSongExist = false;
            Console.WriteLine($"Albums that contain the song '{songName}' are: ");
            foreach (var album in albums)
            {
                if (album.Songs.Count(song => song.Name.ToLower() == songName.ToLower()) <= 0) continue;
                Console.WriteLine(album.Name);
                doAnyAlbumsWithSongExist = true;
            }

            if (doAnyAlbumsWithSongExist)
                Console.WriteLine();
            else
            {
                Console.WriteLine($"No albums exist which contain the song '{songName}'");
                Console.WriteLine();
            }
        }

        public static void SongsOfArtistAfterCertainYear(List<Artist> artists)
        {
            Console.WriteLine("Songs on albums by 'Arctic Monkeys' after 2010:");
            var selectedArtists = artists.Where(artist => artist.Name == "Arctic Monkeys");
            foreach (var artist in selectedArtists)
            {
                foreach (var album in artist.Albums)
                {
                    if (album.YearOfRelease <= 2010) continue;
                    foreach (var song in album.Songs)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }

            Console.WriteLine();
        }

        public static void AlbumsOrderedByNameAndReleasedAfterCertainYear(List<Album> albums)
        {
            var orderedAlbums = albums.OrderBy(album => album.Name).Where(album => album.YearOfRelease > 2010);
            foreach (var album in orderedAlbums)
            {
                Console.WriteLine(album.Name);
            }

            Console.WriteLine();
        }
    }
}
