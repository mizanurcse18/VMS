using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

using PS.Service;
using PS.Web.UI.Models;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics;

namespace PS.Web.UI.Utility
{
    public static class MisUtil
    {
        #region Properties


        #endregion Properties

        #region Ctr

        static MisUtil()
        {

        }

        #endregion Ctr

        #region Methods
        public static bool IsNew(string id)
        {
            bool isNew = string.IsNullOrEmpty(id);
            return isNew;
        }

        #region ItemStock

        #endregion ItemStock

        #region TreeView

        public static TreePageItem GetTreePageItem(IList<TreeViewNode> treeViewNodes)
        {
            var treePageItem = new TreePageItem();

            var rootTreeNode = new TreeViewPageNode();
            FillPageTreeNode(rootTreeNode, treeViewNodes);
            treePageItem.TreeViewPageNodes = rootTreeNode.ChildNodes;

            return treePageItem;
        }

        private static void FillPageTreeNode(TreeViewPageNode parentTreeNode,
           IList<TreeViewNode> treeViewNodes)
        {
            String parentId = null;

            if (!string.IsNullOrEmpty(parentTreeNode.ID))
                parentId = parentTreeNode.ID;

            parentTreeNode.ChildNodes = treeViewNodes
                .Where(node => parentId == node.ParentID).Select(node =>
                {
                    var pageTreeNode = new TreeViewPageNode()
                    {
                        ID = node.ID,
                        ParentID = node.ParentID,
                        NodeName = node.NodeName,
                        IsExpanded = false,
                    };

                    return pageTreeNode;

                }).ToList();

            foreach (var treeNode in parentTreeNode.ChildNodes)
            {
                FillPageTreeNode(treeNode, treeViewNodes);
            }
        }
        private static void FillPageTreeDataForUpdate(IList<TreeViewPageNode> treeViewPageNodes,
            List<TreeViewNode> treeViewNodes)
        {
            foreach (var treeViewPageNode in treeViewPageNodes)
            {
                Trace.WriteLine(treeViewPageNode.ID);
                if (treeViewPageNode.ChildNodes != null && treeViewPageNode.ChildNodes.Any())
                {
                    FillPageTreeDataForUpdate(treeViewPageNode.ChildNodes.ToList(), treeViewNodes);
                }

                treeViewNodes.Add(treeViewPageNode);
            }
        }

        #endregion TreeView

        #endregion Methods

        /// <summary>
        /// This method return true and false according to
        /// match case
        /// </summary>
        /// <typeparam name="T">Any entity</typeparam>
        /// <param name="firstEntity"></param>
        /// <param name="secondEntity"></param>
        /// <param name="firstMatchString"></param>
        /// <param name="secondMatchString"></param>
        /// <returns></returns>
        public static bool HasQuantityChanged<T>(T firstEntity, T secondEntity, string firstMatchString, string secondMatchString)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            decimal firstQuantity = (decimal)props[firstMatchString].GetValue(firstEntity);
            decimal secondQuantity = (decimal)props[secondMatchString].GetValue(secondEntity);
            if (firstQuantity == secondQuantity)
            {
                return true;
            }
            return false;
        }
    }
}