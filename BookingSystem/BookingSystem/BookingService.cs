using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using Entities;

namespace BookingSystem
{
    class BookingService
    {
        private HttpClient _client = new HttpClient();

        public async Task<string> GetBookings()
        {
            var response = await _client.GetAsync("https://localhost:7114/api/bookings");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return data;
        }

        public async Task SendBooking(Bookings booking)
        {
            await _client.PostAsJsonAsync("https://localhost:7114/api/bookings", booking);
        }


        public async Task<string> GetPitches()
        {
            var response = await _client.GetAsync("https://localhost:7114/api/pitches");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return data;
        }

        public async Task SendPitches(Pitches pitches)
        {
            await _client.PostAsJsonAsync("https://localhost:7114/api/pitches", pitches);
        }

        public async Task<string> GetBookers()
        {
            var response = await _client.GetAsync("https://localhost:7114/api/booker");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return data;
        }

        public async Task SendBookers(Booker bookers)
        {
            await _client.PostAsJsonAsync("https://localhost:7114/api/booker", bookers);
        }
    }
}
