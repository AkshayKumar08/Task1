# Flask Video Streaming Application

This is a simple Flask server for streaming video files of different resolutions.

## Requirements

- Python 3.x
- Flask

## Installation

1. Clone the repository:

    ```bash
    git clone todo
    ```

2. Navigate to the project directory:

    ```bash
    cd tasks1/video_server
    ```

3. Install dependencies:

    ```bash
    pip install virtualenv
    ```

3. Create virtual Environment:

    ```bash
    virtualenv venv
    ```

4. Activate environment:

    For windows: 
    ```bash
    venv/Scripts/activate.bat
    ```

    For MacOs/Linux:
    ```bash
    venv/Scripts/activate
    ```

5. Run server
    ```bash
    python app.py
    ````

## Usage

1. Ensure that your video files (144p.mp4, 360p.mp4, and 720p.mp4) are located in the `videos/` directory within the project `video_server`.

2. Run the Flask application:

    ```bash
    python app.py
    ```

3. Open your web browser and navigate to the following URLs to stream the video files:

    - [http://localhost:8000/video/144](http://localhost:8000/video/144)
    - [http://localhost:8000/video/360](http://localhost:8000/video/360)
    - [http://localhost:8000/video/720](http://localhost:8000/video/720)

## Logging

The application logs information to a file named `app.txt` in the same directory as `app.py`. It logs when a video file is being streamed and when a requested video file is not found.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
