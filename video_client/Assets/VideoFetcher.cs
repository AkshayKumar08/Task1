using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;


public class VideoFetcher : MonoBehaviour {

    private VideoPlayer videoPlayer;
    public RenderTexture renderTexture;
    private Material videoMaterial;

    void Start() {
        string videoUrl = "http://localhost:8000/video/144";
        

        renderTexture = new RenderTexture(1024, 1024, 1);
        Material videoMaterial = new Material(Shader.Find("Unlit/Texture"));
        videoMaterial.mainTexture = renderTexture;

        
        GameObject videoMesh = GameObject.CreatePrimitive(PrimitiveType.Quad);
        videoMesh.transform.localScale = new Vector3(10f, 6f, 1f);
        videoMesh.GetComponent<Renderer>().material = videoMaterial;

        StartCoroutine(FetchVideo(videoUrl));
    }

    IEnumerator FetchVideo(string videoUrl){
        using (UnityWebRequest webRequest = UnityWebRequest.Get(videoUrl)) {
            yield return webRequest.SendWebRequest();

            if( webRequest.result != UnityWebRequest.Result.Success){
                Debug.LogError("Failed to fetch video: " + webRequest.error);
                yield break;
            }

        
            // // Get the video bytes from the response
            byte[] videoBytes = webRequest.downloadHandler.data;
            // Create a temporary file path for the video
            string tempFilePath = Application.persistentDataPath + "/tempVideo.mp4";
            // Write the video bytes to a temporary file
            System.IO.File.WriteAllBytes(tempFilePath, videoBytes);
            // Create a new VideoPlayer component
            videoPlayer = gameObject.AddComponent<VideoPlayer>();
            videoPlayer.targetTexture = renderTexture;

            // Set the video source to the temporary file path
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = videoUrl;

            // Play the video
            videoPlayer.Play();

        }
        
    }

    void Update()
    {
        
    }
}
