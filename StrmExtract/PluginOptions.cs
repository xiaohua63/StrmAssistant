using Emby.Web.GenericEdit;
using Emby.Web.GenericEdit.Common;
using Emby.Web.GenericEdit.Validation;
using MediaBrowser.Model.Attributes;
using MediaBrowser.Model.LocalizationAttributes;
using StrmExtract.Properties;
using System.Collections.Generic;
using System.ComponentModel;

namespace StrmExtract
{
    public class PluginOptions: EditableOptionsBase
    {

        [DisplayNameL("PluginOptions_EditorTitle_Strm_Extract", typeof(Resources))]
        public override string EditorTitle => Resources.PluginOptions_EditorTitle_Strm_Extract;

        //public override string EditorDescription => "Strm Extract Description";

        [DisplayNameL("PluginOptions_MaxConcurrentCount_Max_Concurrent_Count", typeof(Resources))]
        [DescriptionL("PluginOptions_MaxConcurrentCount_Max_Concurrent_Count_must_be_between_1_to_10__Default_is_1_", typeof(Resources))]
        [MediaBrowser.Model.Attributes.Required]
        public int MaxConcurrentCount { get; set; } = 1;

        protected override void Validate(ValidationContext context)
        {
            if (MaxConcurrentCount<1 || MaxConcurrentCount>10)
            {
                context.AddValidationError(nameof(MaxConcurrentCount), "Max Concurrent Count must be between 1 to 10.");
            }
        }

        [DisplayNameL("PluginOptions_StrmOnly_Strm_Only", typeof(Resources))]
        [DescriptionL("PluginOptions_StrmOnly_Extract_media_info_of_Strm_only__Default_is_True_", typeof(Resources))]
        [MediaBrowser.Model.Attributes.Required]
        public bool StrmOnly { get; set; } = true;

        [DisplayNameL("PluginOptions_IncludeExtra_Include_Extra", typeof(Resources))]
        [DescriptionL("PluginOptions_IncludeExtra_Include_media_extras_to_extract__Default_is_False_", typeof(Resources))]
        [MediaBrowser.Model.Attributes.Required]
        public bool IncludeExtra { get; set; } = false;

        [DisplayNameL("PluginOptions_CatchupMode_Catch_up_Mode__Experimental_", typeof(Resources))]
        [DescriptionL("PluginOptions_CatchupMode_Catch_up_users_favorites__exclusive_to_Strm___Default_is_False_", typeof(Resources))]
        [MediaBrowser.Model.Attributes.Required]
        public bool CatchupMode { get; set; } = false;
    }
}
