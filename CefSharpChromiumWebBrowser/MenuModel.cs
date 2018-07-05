using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpChromiumWebBrowser
{
    public class MenuModel : IMenuModel
    {
        public int Count => throw new NotImplementedException();

        public bool AddCheckItem(CefMenuCommand commandId, string label)
        {
            throw new NotImplementedException();
        }

        public bool AddItem(CefMenuCommand commandId, string label)
        {
            throw new NotImplementedException();
        }

        public bool AddRadioItem(CefMenuCommand commandId, string label, int groupId)
        {
            throw new NotImplementedException();
        }

        public bool AddSeparator()
        {
            throw new NotImplementedException();
        }

        public IMenuModel AddSubMenu(CefMenuCommand commandId, string label)
        {
            throw new NotImplementedException();
        }

        public bool Clear()
        {
            throw new NotImplementedException();
        }

        public bool GetAccelerator(CefMenuCommand commandId, out int keyCode, out bool shiftPressed, out bool ctrlPressed, out bool altPressed)
        {
            throw new NotImplementedException();
        }

        public bool GetAcceleratorAt(int index, out int keyCode, out bool shiftPressed, out bool ctrlPressed, out bool altPressed)
        {
            throw new NotImplementedException();
        }

        public CefMenuCommand GetCommandIdAt(int index)
        {
            throw new NotImplementedException();
        }

        public int GetGroupId(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public int GetGroupIdAt(int index)
        {
            throw new NotImplementedException();
        }

        public int GetIndexOf(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public string GetLabel(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public string GetLabelAt(int index)
        {
            throw new NotImplementedException();
        }

        public IMenuModel GetSubMenu(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public IMenuModel GetSubMenuAt(int index)
        {
            throw new NotImplementedException();
        }

        public MenuItemType GetType(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public MenuItemType GetTypeAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool HasAccelerator(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public bool HasAcceleratorAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool InsertCheckItemAt(int index, CefMenuCommand commandId, string label)
        {
            throw new NotImplementedException();
        }

        public bool InsertItemAt(int index, CefMenuCommand commandId, string label)
        {
            throw new NotImplementedException();
        }

        public bool InsertRadioItemAt(int index, CefMenuCommand commandId, string label, int groupId)
        {
            throw new NotImplementedException();
        }

        public bool InsertSeparatorAt(int index)
        {
            throw new NotImplementedException();
        }

        public IMenuModel InsertSubMenuAt(int index, CefMenuCommand commandId, string label)
        {
            throw new NotImplementedException();
        }

        public bool IsChecked(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public bool IsCheckedAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabledAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool IsVisible(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public bool IsVisibleAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool Remove(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAccelerator(CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAcceleratorAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool SetAccelerator(CefMenuCommand commandId, int keyCode, bool shiftPressed, bool ctrlPressed, bool altPressed)
        {
            throw new NotImplementedException();
        }

        public bool SetAcceleratorAt(int index, int keyCode, bool shiftPressed, bool ctrlPressed, bool altPressed)
        {
            throw new NotImplementedException();
        }

        public bool SetChecked(CefMenuCommand commandId, bool isChecked)
        {
            throw new NotImplementedException();
        }

        public bool SetCheckedAt(int index, bool isChecked)
        {
            throw new NotImplementedException();
        }

        public bool SetCommandIdAt(int index, CefMenuCommand commandId)
        {
            throw new NotImplementedException();
        }

        public bool SetEnabled(CefMenuCommand commandId, bool enabled)
        {
            throw new NotImplementedException();
        }

        public bool SetEnabledAt(int index, bool enabled)
        {
            throw new NotImplementedException();
        }

        public bool SetGroupId(CefMenuCommand commandId, int groupId)
        {
            throw new NotImplementedException();
        }

        public bool SetGroupIdAt(int index, int groupId)
        {
            throw new NotImplementedException();
        }

        public bool SetLabel(CefMenuCommand commandId, string label)
        {
            throw new NotImplementedException();
        }

        public bool SetLabelAt(int index, string label)
        {
            throw new NotImplementedException();
        }

        public bool SetVisible(CefMenuCommand commandId, bool visible)
        {
            throw new NotImplementedException();
        }

        public bool SetVisibleAt(int index, bool visible)
        {
            throw new NotImplementedException();
        }
    }
}
