from flask import Flask, send_file
import logging
import os

# Configure logging settings
logging.basicConfig(filename='app.txt', level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

# Initialize Flask application
app = Flask(__name__)

# Define paths to video files
VIDEO_FILE_144 = 'videos/144p.mp4'
VIDEO_FILE_360 = 'videos/360p.mp4'
VIDEO_FILE_720 = 'videos/720p.mp4'

# Route for streaming 144p video
@app.route('/video/144')
def stream_video_144():
    if os.path.exists(VIDEO_FILE_144):
        logging.info('Streaming video: 144p')
        return send_file(VIDEO_FILE_144, mimetype='video/mp4')
    logging.error('Video file not found: 144p')
    return "File not found", 404

# Route for streaming 360p video
@app.route('/video/360')
def stream_video_360():
    if os.path.exists(VIDEO_FILE_360):
        logging.info('Streaming video: 360p')
        return send_file(VIDEO_FILE_360, mimetype='video/mp4')    
    logging.error('Video file not found: 360p')
    return "File not found", 404

# Route for streaming 720p video
@app.route('/video/720')
def stream_video_720():
    if os.path.exists(VIDEO_FILE_720):
        logging.info('Streaming video: 720p')
        return send_file(VIDEO_FILE_720, mimetype='video/mp4')
    logging.error('Video file not found: 720p')
    return "File not found", 404

# Run the Flask application
if __name__ == '__main__':
    app.run(host='localhost', port=8000)
