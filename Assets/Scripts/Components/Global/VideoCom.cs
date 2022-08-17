using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Play.AssetDelivery;
using UnityEngine.Video;

public class VideoCom : MonoBehaviour
{
    private VideoPlayer movie;
    [SerializeField] private VideoPlayer videoPlayer;
    void Start()
    {
        StartCoroutine(LoadAssetBundleCoroutine("videos"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadAssetBundleCoroutine(string assetBundleName)
    {

        PlayAssetBundleRequest bundleRequest =
            PlayAssetDelivery.RetrieveAssetBundleAsync(assetBundleName);

        while (!bundleRequest.IsDone)
        {
            if (bundleRequest.Status == AssetDeliveryStatus.WaitingForWifi)
            {
                var userConfirmationOperation = PlayAssetDelivery.ShowCellularDataConfirmation();

                // Wait for confirmation dialog action.
                yield return userConfirmationOperation;

                if ((userConfirmationOperation.Error != AssetDeliveryErrorCode.NoError) ||
                    (userConfirmationOperation.GetResult() != ConfirmationDialogResult.Accepted))
                {
                    // The user did not accept the confirmation - handle as needed.
                }

                // Wait for Wi-Fi connection OR confirmation dialog acceptance before moving on.
                yield return new WaitUntil(() => bundleRequest.Status != AssetDeliveryStatus.WaitingForWifi);
            }

            // Use bundleRequest.DownloadProgress to track download progress.
            // Use bundleRequest.Status to track the status of request.

            yield return null;
        }

        if (bundleRequest.Error != AssetDeliveryErrorCode.NoError)
        {
            // There was an error retrieving the bundle. For error codes NetworkError
            // and InsufficientStorage, you may prompt the user to check their
            // connection settings or check their storage space, respectively, then
            // try again.
            yield return null;
        }

        // Request was successful. Retrieve AssetBundle from request.AssetBundle.
        AssetBundle assetBundle = bundleRequest.AssetBundle;
        WorkWithAssetBundle(assetBundle);
    }

    private void WorkWithAssetBundle(AssetBundle assetBundle)
    {
        VideoClip cube = assetBundle.LoadAsset<VideoClip>("Video1");
        videoPlayer.clip = cube;
        videoPlayer.Play();
    }
}
