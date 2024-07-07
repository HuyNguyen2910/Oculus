/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Oculus.Interaction.DebugTree
{
    public class InteractorGroupNodeUI : MonoBehaviour, INodeUI<IInteractor>
    {
        [SerializeField]
        private RectTransform _childArea;

        [SerializeField]
        private RectTransform _connectingLine;

        [SerializeField]
        private TextMeshProUGUI _label;

        [SerializeField]
        private Image _activeImage;

        [SerializeField]
        private Color _selectColor = Color.green;
        [SerializeField]
        private Color _hoverColor = Color.blue;
        [SerializeField]
        private Color _normalColor = Color.red;
        [SerializeField]
        private Color _disabledColor = Color.grey;

        private const string OBJNAME_FORMAT = "<color=#dddddd><size=85%>{0}</size></color>";

        public RectTransform ChildArea => _childArea;

        private ITreeNode<IInteractor> _boundNode;
        private bool _isRoot = false;
        private bool _isDuplicate = false;

        public void Bind(ITreeNode<IInteractor> node, bool isRoot, bool isDuplicate)
        {
            Assert.IsNotNull(node);

            _isRoot = isRoot;
            _isDuplicate = isDuplicate;
            _boundNode = node;
            _label.text = GetLabelText(node);
        }

        protected virtual void Start()
        {
            this.AssertField(_childArea, nameof(_childArea));
            this.AssertField(_connectingLine, nameof(_connectingLine));
            this.AssertField(_activeImage, nameof(_activeImage));
            this.AssertField(_label, nameof(_label));
        }

        protected virtual void Update()
        {
            switch (_boundNode.Value.State)
            {
                case InteractorState.Select:
                    _activeImage.color = _selectColor; break;
                case InteractorState.Hover:
                    _activeImage.color = _hoverColor; break;
                case InteractorState.Normal:
                    _activeImage.color = _normalColor; break;
                case InteractorState.Disabled:
                    _activeImage.color = _disabledColor; break;
            }

            _childArea.gameObject.SetActive(_childArea.childCount > 0);
            _connectingLine.gameObject.SetActive(!_isRoot);
        }

        private string GetLabelText(ITreeNode<IInteractor> node)
        {
            string label = _isDuplicate ? "<i>" : "";
            if (node.Value is UnityEngine.Object obj)
            {
                label += obj.name + " - ";
            }
            label += string.Format(OBJNAME_FORMAT, node.Value.GetType().Name);
            return label;
        }
    }
}
