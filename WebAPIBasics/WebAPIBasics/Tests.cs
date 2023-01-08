using Newtonsoft.Json.Linq;

namespace WebAPIBasics
{
    public class Tests
    {
        [Test, Order(1)]
        public void UploadFileTest()
        {
            var client = new Client();
            var metadata = client.UploadFile("../../../file.txt", "/WebAPIBasics/file.txt");

            // Ensure that the response contains the metadata for the file
            JToken nameToken, contentHashToken;
            Assert.IsTrue(metadata.TryGetValue("name", out nameToken));
            Assert.IsTrue(metadata.TryGetValue("content_hash", out contentHashToken));
        }

        [Test, Order(2)]
        public void GetFileMetadataTest()
        {
            var client = new Client();
            var metadata = client.GetFileMetadata("/WebAPIBasics/file.txt");

            JToken sizeToken, modifiedToken;
            Assert.IsTrue(metadata.TryGetValue("size", out sizeToken));
            Assert.IsTrue(metadata.TryGetValue("name", out modifiedToken));
        }

        [Test, Order(3)]
        public void DeleteFileTest()
        {
            var client = new Client();
            var metadata = client.DeleteFile("/WebAPIBasics/file.txt");

            JToken sizeToken, modifiedToken, errorToken;
            Assert.IsTrue(metadata.TryGetValue("size", out sizeToken));
            Assert.IsTrue(metadata.TryGetValue("name", out modifiedToken));
            Assert.IsFalse(metadata.TryGetValue("error", out errorToken));
        }
    }
}