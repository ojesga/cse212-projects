using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var results = new List<string>();

        foreach (var word in words)
        {
            // Ignore self-matching words like "aa"
            if (word.Length != 2 || word[0] == word[1])
            {
                continue;
            }

            // Create the reverse string
            string reversed = $"{word[1]}{word[0]}";

            // If we've seen the reverse word before, we found a pair
            if (seen.Contains(reversed))
            {
                results.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return results.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>Dictionary mapping degree names to count</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            if (fields.Length > 3)
            {
                string degree = fields[3].Trim();

                if (!string.IsNullOrEmpty(degree))
                {
                    if (degrees.ContainsKey(degree))
                    {
                        degrees[degree]++;
                    }
                    else
                    {
                        degrees[degree] = 1;
                    }
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams using a dictionary.
    /// Ignores spaces and character case.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize: remove spaces and convert to lower case
        string cleaned1 = word1.Replace(" ", "").ToLower();
        string cleaned2 = word2.Replace(" ", "").ToLower();

        if (cleaned1.Length != cleaned2.Length)
        {
            return false;
        }

        var counts = new Dictionary<char, int>();

        // Count frequency of characters in word1
        foreach (char c in cleaned1)
        {
            if (counts.ContainsKey(c))
            {
                counts[c]++;
            }
            else
            {
                counts[c] = 1;
            }
        }

        // Decrement frequency using characters in word2
        foreach (char c in cleaned2)
        {
            if (!counts.ContainsKey(c) || counts[c] == 0)
            {
                return false;
            }

            counts[c]--;
        }

        return true;
    }

    /// <summary>
    /// Reads earthquake JSON data from USGS and returns string descriptions of each place & magnitude.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summary = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                string place = feature.Properties?.Place ?? "Unknown Location";
                double mag = feature.Properties?.Mag ?? 0.0;

                summary.Add($"{place} - Mag {mag}");
            }
        }

        return summary.ToArray();
    }
}