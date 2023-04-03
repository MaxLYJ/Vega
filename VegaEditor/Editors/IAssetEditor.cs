using VegaEditor.Content;

namespace VegaEditor.Editors
{
    interface IAssetEditor
    {
        Asset Asset { get; }

        void SetAsset(Asset asset);
    }
}
