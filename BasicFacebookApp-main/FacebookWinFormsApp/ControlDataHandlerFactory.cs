using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public static class ControlDataHandlerFactory
    {
        public static readonly Dictionary<string, Type> s_ControlTypeMappings = new Dictionary<string, Type>
        {
            { "PostsDataSection", typeof(Post) },
            { "FriendsDataSection", typeof(User) },
            { "VideosDataSection", typeof(Video) },
            { "GalleryDataSection", typeof(Photo) }
        };
        public static IControlDataHandler<T> CreateHandler<T>(string i_ControlName)
        {
            dynamic dataHandler = null;

            if (i_ControlName == "PostsDataSection")
            {
                dataHandler = new PostsDataHandler();
            }
            else if (i_ControlName == "FriendsDataSection")
            {
                dataHandler = new FriendsDataHandler();
            }
            else if (i_ControlName == "GalleryDataSection")
            {
                dataHandler = new GalleryDataHandler();
            }
            else if (i_ControlName == "VideosDataSection")
            {
                dataHandler = new VideosDataHandler();
            }
            else
            {
                throw new ArgumentException($"Unsupported control name: {i_ControlName}");
            }
            
            return (IControlDataHandler<T>)dataHandler;
        }

        
        public static IControlDataHandler<T> CreateHandlerDynamically<T>(string controlName)
        {
            if (!s_ControlTypeMappings.TryGetValue(controlName, out var targetType))
            {
                throw new ArgumentException($"Unsupported control name: {controlName}");
            }

            // Ensure the resolved type matches T
            if (targetType != typeof(T))
            {
                throw new InvalidOperationException($"Control '{controlName}' does not support type {typeof(T).Name}.");
            }

            // Use the generic CreateHandler<T> method
            return CreateHandler<T>(controlName);
        }

        // Non-generic method to dynamically create a handler based on the control name
        //public static IControlDataHandler CreateHandlerDynamically(string controlName)
        //{
        //    if (!s_ControlTypeMappings.TryGetValue(controlName, out var targetType))
        //    {
        //        throw new ArgumentException($"Unsupported control name: {controlName}");
        //    }

        //    // Use reflection to invoke the generic CreateHandler<T> method
        //    var factoryMethod = typeof(ControlDataHandlerFactory)
        //        .GetMethod(nameof(CreateHandler))
        //        .MakeGenericMethod(targetType);

        //    // Invoke the method and return the result as a non-generic interface
        //    return (IControlDataHandler)factoryMethod.Invoke(null, new object[] { controlName });
        //}




    }

}
