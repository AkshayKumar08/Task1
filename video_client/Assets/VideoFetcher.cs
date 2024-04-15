using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

public class VideoFetcher : MonoBehaviour {

    private VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public RenderTexture renderTexture; // RenderTexture to render the video
    private Material videoMaterial; // Material to apply the video texture

    void Start() {
        // Define the URL of the video to fetch
        string videoUrl = "http://localhost:8000/video/144";
        
        // Create a new RenderTexture with dimensions 1024x1024
        renderTexture = new RenderTexture(1024, 1024, 1);

        // Create a new material with the "Unlit/Texture" shader
        Material videoMaterial = new Material(Shader.Find("Unlit/Texture"));
        // Set the main texture of the material to the Render Texture
        videoMaterial.mainTexture = renderTexture;

        // Create a GameObject with a mesh (quad) for displaying the video
        GameObject videoMesh = GameObject.CreatePrimitive(PrimitiveType.Quad);
        // Scale the quad to fit the screen
        videoMesh.transform.localScale = new Vector3(10f, 6f, 1f);
        // Apply the video material to the renderer of the quad GameObject
        videoMesh.GetComponent<Renderer>().material = videoMaterial;

        // Start the coroutine to fetch and play the video
        StartCoroutine(FetchVideo(videoUrl));
    }

    IEnumerator FetchVideo(string videoUrl){
        using (UnityWebRequest webRequest = UnityWebRequest.Get(videoUrl)) {
            yield return webRequest.SendWebRequest();

            if( webRequest.result != UnityWebRequest.Result.Success){
                // Log an error if the video fetch fails
                Debug.LogError("Failed to fetch video: " + webRequest.error);
                yield break; // Exit the coroutine
            }

            // Get the video bytes from the response
            byte[] videoBytes = webRequest.downloadHandler.data;
            // Create a temporary file path for the video
            string tempFilePath = Application.persistentDataPath + "/tempVideo.mp4";
            // Write the video bytes to a temporary file
            System.IO.File.WriteAllBytes(tempFilePath, videoBytes);

            // Create a new VideoPlayer component
            videoPlayer = gameObject.AddComponent<VideoPlayer>();
            // Set the target RenderTexture for rendering the video
            videoPlayer.targetTexture = renderTexture;

            // Set the video source to the temporary file path
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = videoUrl;

            // Play the video
            videoPlayer.Play();
        }
    }

    void Update() {
        // No update logic needed for now
    }
}
