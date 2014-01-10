﻿using System;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Xpand.ExpressApp.Win.SystemModule{
    public class ImmediateRefreshListViewController : ViewController<ListView> {
        GridView _gridViewCore;

        protected override void OnViewControlsCreated(){
            base.OnViewControlsCreated();
            var gridControl = (GridControl) View.Editor.Control;
            _gridViewCore = (GridView) gridControl.FocusedView;
            foreach (GridColumn column in _gridViewCore.Columns){
                var attr = View.ObjectTypeInfo.FindMember(column.FieldName).FindAttribute<ImmediatePostDataAttribute>();
                if (attr != null){
                    column.ColumnEdit.EditValueChanged += ColumnEdit_EditValueChanged;
                }
            }
        }

        void ColumnEdit_EditValueChanged(object sender, EventArgs e) {
            _gridViewCore.PostEditor();
        }
    }
}