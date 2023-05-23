import React, { useState, useEffect } from 'react';
import axios from 'axios';

const UrlShortener = () => {
  const [longUrl, setLongUrl] = useState('');
  const [shortUrl, setShortUrl] = useState('');
  const [urls, setUrls] = useState([]);

  useEffect(() => {
    fetchData();
  }, [shortUrl]);

  const fetchData = async () => {
    try {
      debugger;
      const response = await axios.get('https://localhost:7036/api/url'); 
      setUrls(response.data);
      fetchData();
    } catch (error) {
      console.error(error);
    }
  };

  const handleUrlChange = (e) => {
    setLongUrl(e.target.value);
  };

  const handleShortenUrl = async () => {
    try {
      const headers = {
        'Content-Type': 'application/json;'
    }

      const response = await axios.post('https://localhost:7036/api/url', longUrl, {headers} );
      setShortUrl(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <h2>URL Shortener</h2>
      <div>
        <input type="text" value={longUrl} onChange={handleUrlChange} />
        <button onClick={handleShortenUrl}>Shorten</button>
      </div>
      {shortUrl && (
        <div>
          <p>Shortened URL:</p>
          <a href={shortUrl} target="_blank" rel="noopener noreferrer">
            {shortUrl}
          </a>
        </div>
      )}
      <div>
        <h2>List of URLs</h2>
        {urls.map(url => (
          <div key={url.id}>
            <p>Original URL: {url.originalUrl}</p>
            <p>Shortened URL: {url.shortAlias}</p>
          </div>
        ))}
    </div>


    </div>
  );
};

export default UrlShortener;
