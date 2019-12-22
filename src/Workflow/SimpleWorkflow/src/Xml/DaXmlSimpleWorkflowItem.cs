// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ejyle.DevAccelerate.SimpleWorkflow.Xml
{
    [SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(TypeName = "workflowItem", AnonymousType = true, Namespace = "https://devaccelerate.github.io/schema/simple-workflow-v10.html")]
    public class DaXmlSimpleWorkflowItem : DaXmlSimpleWorkflowItem<DaXmlSimpleWorkflowItemSetting>
    {
    }

    [SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(TypeName="workflowItem", AnonymousType = true, Namespace = "https://devaccelerate.github.io/schema/simple-workflow-v10.html")]
    public class DaXmlSimpleWorkflowItem<TSimpleWorkflowItemSetting> : IDaSimpleWorkflowItem<TSimpleWorkflowItemSetting>
        where TSimpleWorkflowItemSetting : IDaSimpleWorkflowItemSetting
    {
        private DaSimpleWorkflowItemType _workflowItemType;
        private string _name;
        private bool _includeMainInput;
        private string _type;
        private string _itemInput;
        private DaSimpleWorkflowItemActionResultType _actionResultType;
        private TSimpleWorkflowItemSetting[] _workflowItemSettings;

        [XmlAttributeAttribute(AttributeName = "workflowItemSettings")]
        public TSimpleWorkflowItemSetting[] WorkflowItemSettings
        {
            get
            {
                return this._workflowItemSettings;
            }
            set
            {
                this._workflowItemSettings = value;
            }
        }

        [XmlAttributeAttribute(AttributeName= "workflowItemType")]
        public DaSimpleWorkflowItemType WorkflowItemType
        {
            get
            {
                return this._workflowItemType;
            }
            set
            {
                this._workflowItemType = value;
            }
        }

        [XmlAttributeAttribute(AttributeName = "actionResultType")]
        public DaSimpleWorkflowItemActionResultType ActionResultType
        {
            get
            {
                return _actionResultType;
            }
            set
            {
                _actionResultType = value;
            }
        }

        [XmlAttributeAttribute(AttributeName = "name")]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [XmlAttributeAttribute(AttributeName = "includeMainInput")]
        public bool IncludeMainInput
        {
            get
            {
                return this._includeMainInput;
            }
            set
            {
                this._includeMainInput = value;
            }
        }

        [XmlAttributeAttribute(AttributeName = "type")]
        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        [XmlAttributeAttribute(AttributeName = "itemInput")]
        public string ItemInput
        {
            get
            {
                return this._itemInput;
            }
            set
            {
                this._itemInput = value;
            }
        }
    }


}
