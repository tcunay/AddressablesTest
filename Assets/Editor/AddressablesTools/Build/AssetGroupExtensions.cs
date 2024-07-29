using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;

namespace Editor.AddressablesTools.Build
{
    public static class AssetGroupExtensions
    {
        public static bool IsRemote(this AddressableAssetGroup group)
        {
            BundledAssetGroupSchema schema = group.GetSchema<BundledAssetGroupSchema>();
            
            if (schema == null)
                return false;

            return schema.BuildPath.IsRemote() ||
                   schema.LoadPath.IsRemote();
        }

        private static bool IsRemote(this ProfileValueReference profile)
        {
            return profile.GetValue(AddressableAssetSettingsDefaultObject.Settings).Contains("http");
        }
    }
}