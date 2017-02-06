using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Tunynet.Utilities;

namespace Peace.Com.Mvc
{
    /// <summary>
    /// 封装对HtmlHelper的扩展方法
    /// </summary>
    public static class HtmlHelperExtensions
    {
        #region 图标

        /// <summary>
        /// 输出图标
        /// </summary>
        /// <param name="htmlHelper">被扩展的HtmlHelper实例</param>
        /// <param name="type">图标类型</param>
        /// <param name="title">鼠标提示文字</param>
        /// <param name="htmlAttributes">html属性集合</param>
        /// <returns>图标的html代码</returns>
        public static MvcHtmlString Icon(this HtmlHelper htmlHelper, IconTypes type, string title = null, object htmlAttributes = null)
        {
            TagBuilder span = new TagBuilder("span");
            switch (type)
            {

                case IconTypes.TriangleUp:
                    span.AddCssClass("tn-icon-triangle-up");
                    break;
                case IconTypes.TriangleRight:
                    span.AddCssClass("tn-icon-triangle-right");
                    break;
                case IconTypes.TriangleDown:
                    span.AddCssClass("tn-icon-triangle-down");
                    break;
                case IconTypes.TriangleLeft:
                    span.AddCssClass("tn-icon-triangle-left");
                    break;

                case IconTypes.CollapseOpen:
                    span.AddCssClass("tn-icon-collapse-open");
                    break;
                case IconTypes.CollapseClose:
                    span.AddCssClass("tn-icon-collapse-close");
                    break;


                case IconTypes.Download:
                    span.AddCssClass("tn-icon-download");
                    break;
                case IconTypes.Upload:
                    span.AddCssClass("tn-icon-upload");
                    break;

                case IconTypes.Expand:
                    span.AddCssClass("tn-icon-expand");
                    break;
                case IconTypes.Fold:
                    span.AddCssClass("tn-icon-fold");
                    break;
                case IconTypes.SlideNext:
                    span.AddCssClass("tn-icon-slide-next");
                    break;
                case IconTypes.SlidePrev:
                    span.AddCssClass("tn-icon-slide-prev");
                    break;
                case IconTypes.First:
                    span.AddCssClass("tn-icon-first");
                    break;
                case IconTypes.Last:
                    span.AddCssClass("tn-icon-last");
                    break;
                case IconTypes.Add:
                    span.AddCssClass("tn-icon-add");
                    break;
                case IconTypes.Write:
                    span.AddCssClass("tn-icon-write");
                    break;
                case IconTypes.Update:
                    span.AddCssClass("tn-icon-update");
                    break;
                case IconTypes.Set:
                    span.AddCssClass("tn-icon-set");
                    break;
                case IconTypes.Config:
                    span.AddCssClass("tn-icon-config");
                    break;
                case IconTypes.Cross:
                    span.AddCssClass("tn-icon-cross");
                    break;
                case IconTypes.Accept:
                    span.AddCssClass("tn-icon-accept");
                    break;
                case IconTypes.RotateLeft:
                    span.AddCssClass("tn-icon-rotate-left");
                    break;
                case IconTypes.RotateRight:
                    span.AddCssClass("tn-icon-rotate-right");
                    break;
                case IconTypes.Enlarge:
                    span.AddCssClass("tn-icon-enlarge");
                    break;
                case IconTypes.School:
                    span.AddCssClass("tn-icon-school");
                    break;
                case IconTypes.Question:
                    span.AddCssClass("tn-icon-question");
                    break;
                case IconTypes.Friendly:
                    span.AddCssClass("tn-icon-friendly");
                    break;
                case IconTypes.Sneak:
                    span.AddCssClass("tn-icon-sneak");
                    break;
                //case IconTypes.Forward:
                //    span.AddCssClass("tn-icon-forward");
                //    break;
                case IconTypes.Stop:
                    span.AddCssClass("tn-icon-stop");
                    break;
                //case IconTypes.Set:
                //    span.AddCssClass("tn-icon-set");
                //    break;
                case IconTypes.Elite:
                    span.AddCssClass("tn-icon-elite");
                    break;
                case IconTypes.EmailOpen:
                    span.AddCssClass("tn-icon-email-open");
                    break;
                case IconTypes.Top:
                    span.AddCssClass("tn-icon-top");
                    break;
                case IconTypes.Flag:
                    span.AddCssClass("tn-icon-flag");
                    break;
                case IconTypes.Lock:
                    span.AddCssClass("tn-icon-lock");
                    break;
                case IconTypes.Key:
                    span.AddCssClass("tn-icon-key");
                    break;
                case IconTypes.Limit:
                    span.AddCssClass("tn-icon-limit");
                    break;
                case IconTypes.Coins:
                    span.AddCssClass("tn-icon-coins");
                    break;
                case IconTypes.Fire:
                    span.AddCssClass("tn-icon-fire");
                    break;
                case IconTypes.Move:
                    span.AddCssClass("tn-icon-move");
                    break;
                case IconTypes.Approve:
                    span.AddCssClass("tn-icon-approve");
                    break;
                case IconTypes.View:
                    span.AddCssClass("tn-icon-view");
                    break;
                case IconTypes.ThumbUp:
                    span.AddCssClass("tn-icon-thumb-up");
                    break;
                case IconTypes.ThumbDown:
                    span.AddCssClass("tn-icon-thumb-down");
                    break;
                case IconTypes.Share:
                    span.AddCssClass("tn-icon-share");
                    break;
                case IconTypes.Bubble:
                    span.AddCssClass("tn-icon-bubble");
                    break;
                case IconTypes.Favorite:
                    span.AddCssClass("tn-icon-favorite");
                    break;
                case IconTypes.Star:
                    span.AddCssClass("tn-icon-star");
                    break;
                case IconTypes.Feed:
                    span.AddCssClass("tn-icon-feed");
                    break;
                //case IconTypes.QuotesBefore:
                //    span.AddCssClass("tn-icon-quotes-before");
                //    break;
                //case IconTypes.Topic:
                //    span.AddCssClass("tn-icon-topic");
                //    break;
                case IconTypes.Label:
                    span.AddCssClass("tn-icon-label");
                    break;
                case IconTypes.User:
                    span.AddCssClass("tn-icon-user");
                    break;
                case IconTypes.UserAdd:
                    span.AddCssClass("tn-icon-user-add");
                    break;
                case IconTypes.UserAllow:
                    span.AddCssClass("tn-icon-user-allow");
                    break;
                case IconTypes.UserStop:
                    span.AddCssClass("tn-icon-user-stop");
                    break;
                case IconTypes.UserRelation:
                    span.AddCssClass("tn-icon-user-relation");
                    break;
                case IconTypes.UserAvatar:
                    span.AddCssClass("tn-icon-user-avatar");
                    break;
                case IconTypes.UserInvite:
                    span.AddCssClass("tn-icon-user-invite");
                    break;
                case IconTypes.UserCard:
                    span.AddCssClass("tn-icon-user-card");
                    break;
                case IconTypes.Chain:
                    span.AddCssClass("tn-icon-chain");
                    break;
                case IconTypes.Pen:
                    span.AddCssClass("tn-icon-pen");
                    break;
                case IconTypes.Creator:
                    span.AddCssClass("tn-icon-creator");
                    break;
                case IconTypes.Manager:
                    span.AddCssClass("tn-icon-manager");
                    break;
                case IconTypes.BrowseList:
                    span.AddCssClass("tn-icon-browse-list");
                    break;
                case IconTypes.BrowseDetail:
                    span.AddCssClass("tn-icon-browse-detail");
                    break;
                case IconTypes.BrowseMedium:
                    span.AddCssClass("tn-icon-browse-medium");
                    break;
                case IconTypes.BrowseSmall:
                    span.AddCssClass("tn-icon-browse-small");
                    break;
                case IconTypes.BrowseSlide:
                    span.AddCssClass("tn-icon-browse-slide");
                    break;
                case IconTypes.Dress:
                    span.AddCssClass("tn-icon-dress");
                    break;
                case IconTypes.Jump:
                    span.AddCssClass("tn-icon-jump");
                    break;
                case IconTypes.Zomm:
                    span.AddCssClass("tn-icon-zomm");
                    break;
                case IconTypes.Camera:
                    span.AddCssClass("tn-icon-camera");
                    break;
                case IconTypes.Calendar:
                    span.AddCssClass("tn-icon-calendar");
                    break;
                //case IconTypes.Color:
                //    span.AddCssClass("tn-icon-color");
                //    break;
                case IconTypes.Admin:
                    span.AddCssClass("tn-icon-admin");
                    break;
                case IconTypes.Auadmin:
                    span.AddCssClass("tn-icon-auadmin");
                    break;
                case IconTypes.Female:
                    span.AddCssClass("tn-icon-female");
                    break;
                case IconTypes.Male:
                    span.AddCssClass("tn-icon-male");
                    break;
                case IconTypes.Movie:
                    span.AddCssClass("tn-icon-moive");
                    break;
                case IconTypes.Sound:
                    span.AddCssClass("tn-icon-sound");
                    break;
                case IconTypes.Music:
                    span.AddCssClass("tn-icon-music");
                    break;
                case IconTypes.Skin:
                    span.AddCssClass("tn-icon-skin");
                    break;
                case IconTypes.Blog:
                    span.AddCssClass("tn-icon-blog");
                    break;
                case IconTypes.Archive:
                    span.AddCssClass("tn-icon-archive");
                    break;
                case IconTypes.Forum:
                    span.AddCssClass("tn-icon-forum");
                    break;
                case IconTypes.Vote:
                    span.AddCssClass("tn-icon-vote");
                    break;
                case IconTypes.News:
                    span.AddCssClass("tn-icon-news");
                    break;
                case IconTypes.Cms:
                    span.AddCssClass("tn-icon-cms");
                    break;
                case IconTypes.Job:
                    span.AddCssClass("tn-icon-job");
                    break;
                case IconTypes.World:
                    span.AddCssClass("tn-icon-world");
                    break;
                case IconTypes.Home:
                    span.AddCssClass("tn-icon-home");
                    break;
                //case IconTypes.Question:
                //    span.AddCssClass("tn-icon-question");
                //    break;
                case IconTypes.Notice:
                    span.AddCssClass("tn-icon-notice");
                    break;
                case IconTypes.Escalator:
                    span.AddCssClass("tn-icon-escalator");
                    break;
                case IconTypes.Alert:
                    span.AddCssClass("tn-icon-alert");
                    break;
                case IconTypes.Exclamation:
                    span.AddCssClass("tn-icon-exclamation");
                    break;
                case IconTypes.CrossCircle:
                    span.AddCssClass("tn-icon-cross-circle");
                    break;
                case IconTypes.AcceptCircle:
                    span.AddCssClass("tn-icon-accept-circle");
                    break;
                case IconTypes.Apply:
                    span.AddCssClass("tn-icon-apply");
                    break;
                case IconTypes.Logout:
                    span.AddCssClass("tn-icon-logout");
                    break;
                case IconTypes.Join:
                    span.AddCssClass("tn-icon-join");
                    break;
                case IconTypes.Quit:
                    span.AddCssClass("tn-icon-quit");
                    break;
                case IconTypes.Emotion:
                    span.AddCssClass("tn-icon-emotion");
                    break;
                case IconTypes.PaperClip:
                    span.AddCssClass("tn-icon-paper-clip");
                    break;
                case IconTypes.Folder:
                    span.AddCssClass("tn-icon-folder");
                    break;
                case IconTypes.Album:
                    span.AddCssClass("tn-icon-album");
                    break;
                case IconTypes.Banned:
                    span.AddCssClass("tn-icon-colorful tn-icon-colorful-banned");
                    break;
                case IconTypes.Moderated:
                    span.AddCssClass("tn-icon-colorful tn-icon-colorful-moderated");
                    break;
                case IconTypes.Group:
                    span.AddCssClass("tn-icon-group");
                    break;
                case IconTypes.Event:
                    span.AddCssClass("tn-icon-event");
                    break;
                case IconTypes.Find:
                    span.AddCssClass("tn-icon-find");
                    break;
                case IconTypes.Picture:
                    span.AddCssClass("tn-icon-picture");
                    break;
                //case IconTypes.Coins:
                //    span.AddCssClass("tn-icon-coins");
                //    break;
                case IconTypes.Topic:
                    span.AddCssClass("tn-icon-topic");
                    break;
                //case IconTypes.Fire:
                //    span.AddCssClass("tn-icon-fire");
                //    break;
                case IconTypes.QuotesBefore:
                    span.AddCssClass("tn-icon-quotes-before");
                    break;
                case IconTypes.Color:
                    span.AddCssClass("tn-icon-color");
                    break;
                case IconTypes.App:
                    span.AddCssClass("tn-icon-app");
                    break;
                case IconTypes.Market:
                    span.AddCssClass("tn-icon-market");
                    break;
                case IconTypes.Answer:
                    span.AddCssClass("tn-icon-answer");
                    break;
                case IconTypes.Microblog:
                    span.AddCssClass("tn-icon-microblog");
                    break;
                case IconTypes.At:
                    span.AddCssClass("tn-icon-at");
                    break;
                case IconTypes.Play:
                    span.AddCssClass("tn-icon-play");
                    break;
                case IconTypes.Pause:
                    span.AddCssClass("tn-icon-pause");
                    break;
                case IconTypes.Discovery:
                    span.AddCssClass("tn-icon-discovery");
                    break;
                case IconTypes.Gift:
                    span.AddCssClass("tn-icon-gift");
                    break;
                case IconTypes.Function:
                    span.AddCssClass("tn-icon-function");
                    break;
                case IconTypes.Chart:
                    span.AddCssClass("tn-icon-chart");
                    break;
                case IconTypes.Clock:
                    span.AddCssClass("tn-icon-clock");
                    break;
                case IconTypes.Pending:
                    span.AddCssClass("tn-icon-pending");
                    break;
                case IconTypes.Datasheet:
                    span.AddCssClass("tn-icon-datasheet");
                    break;
                case IconTypes.System:
                    span.AddCssClass("tn-icon-system");
                    break;
                case IconTypes.Product:
                    span.AddCssClass("tn-icon-product");
                    break;
                case IconTypes.AddPicture:
                    span.AddCssClass("tn-icon-add-picture");
                    break;
                case IconTypes.Ask:
                    span.AddCssClass("tn-icon-ask");
                    break;
                case IconTypes.PointMall:
                    span.AddCssClass("tn-icon-pointmall");
                    break;
                case IconTypes.Bar:
                    span.AddCssClass("tn-icon-bar");
                    break;
                case IconTypes.Wiki:
                    span.AddCssClass("tn-icon-world");
                    break;
                case IconTypes.SmallTriangleUp:
                    span.AddCssClass("tn-smallicon-triangle-up");
                    break;
                case IconTypes.SmallTriangleRight:
                    span.AddCssClass("tn-smallicon-triangle-right");
                    break;
                case IconTypes.SmallTriangleDown:
                    span.AddCssClass("tn-smallicon-triangle-down");
                    break;
                case IconTypes.SmallTriangleLeft:
                    span.AddCssClass("tn-smallicon-triangle-left");
                    break;
                case IconTypes.SmallCollapseOpen:
                    span.AddCssClass("tn-smallicon-collapse-open");
                    break;
                case IconTypes.SmallCollapseClose:
                    span.AddCssClass("tn-smallicon-collapse-close");
                    break;
                case IconTypes.SmallDownload:
                    span.AddCssClass("tn-smallicon-download");
                    break;
                case IconTypes.SmallUpload:
                    span.AddCssClass("tn-smallicon-upload");
                    break;
                case IconTypes.SmallWrite:
                    span.AddCssClass("tn-smallicon-write");
                    break;
                case IconTypes.SmallUpdate:
                    span.AddCssClass("tn-smallicon-update");
                    break;
                case IconTypes.SmallSet:
                    span.AddCssClass("tn-smallicon-set");
                    break;
                case IconTypes.SmallConfig:
                    span.AddCssClass("tn-smallicon-config");
                    break;
                case IconTypes.SmallAdd:
                    span.AddCssClass("tn-smallicon-add");
                    break;
                case IconTypes.SmallCross:
                    span.AddCssClass("tn-smallicon-cross");
                    break;
                case IconTypes.SmallAccept:
                    span.AddCssClass("tn-smallicon-accept");
                    break;
                case IconTypes.SmallStop:
                    span.AddCssClass("tn-smallicon-stop");
                    break;
                case IconTypes.SmallExpand:
                    span.AddCssClass("tn-smallicon-expand");
                    break;
                case IconTypes.SmallFold:
                    span.AddCssClass("tn-smallicon-fold");
                    break;
                case IconTypes.SmallSlideNext:
                    span.AddCssClass("tn-smallicon-slide-next");
                    break;
                case IconTypes.SmallSlidePrev:
                    span.AddCssClass("tn-smallicon-slide-prev");
                    break;
                case IconTypes.SmallSlideFirst:
                    span.AddCssClass("tn-smallicon-slide-first");
                    break;
                case IconTypes.SmallSlideLast:
                    span.AddCssClass("tn-smallicon-slide-last");
                    break;
                case IconTypes.SmallTop:
                    span.AddCssClass("tn-smallicon-top");
                    break;
                case IconTypes.SmallMicroblog:
                    span.AddCssClass("tn-smallicon-microblog");
                    break;
                case IconTypes.SmallRotateLeft:
                    span.AddCssClass("tn-smallicon-rotate-left");
                    break;
                case IconTypes.SmallRotateRight:
                    span.AddCssClass("tn-smallicon-rotate-right");
                    break;
                case IconTypes.SmallEnlarge:
                    span.AddCssClass("tn-smallicon-enlarge");
                    break;
                case IconTypes.SmallLabel:
                    span.AddCssClass("tn-smallicon-label");
                    break;
                case IconTypes.SmallFind:
                    span.AddCssClass("tn-smallicon-find");
                    break;
                case IconTypes.SmallAlert:
                    span.AddCssClass("tn-smallicon-alert");
                    break;
                case IconTypes.SmallElite:
                    span.AddCssClass("tn-smallicon-elite");
                    break;
                case IconTypes.SmallFriendly:
                    span.AddCssClass("tn-smallicon-friendly");
                    break;
                case IconTypes.SmallSneak:
                    span.AddCssClass("tn-smallicon-sneak");
                    break;
                case IconTypes.SmallFemale:
                    span.AddCssClass("tn-smallicon-female");
                    break;
                case IconTypes.SmallMale:
                    span.AddCssClass("tn-smallicon-male");
                    break;
                case IconTypes.SmallAsk:
                    span.AddCssClass("tn-smallicon-ask");
                    break;
                case IconTypes.SmallGroup:
                    span.AddCssClass("tn-smallicon-group");
                    break;
                case IconTypes.SmallPointMall:
                    span.AddCssClass("tn-smallicon-pointmall");
                    break;
                case IconTypes.SmallBar:
                    span.AddCssClass("tn-smallicon-bar");
                    break;
                //32*32_big
                case IconTypes.BigTriangleUp:
                    span.AddCssClass("tn-bigicon-triangle-up");
                    break;
                case IconTypes.BigTriangleRight:
                    span.AddCssClass("tn-bigicon-triangle-right");
                    break;
                case IconTypes.BigTriangleDown:
                    span.AddCssClass("tn-bigicon-triangle-down");
                    break;
                case IconTypes.BigTriangleLeft:
                    span.AddCssClass("tn-bigicon-triangle-left");
                    break;
                case IconTypes.BigCollapseOpen:
                    span.AddCssClass("tn-bigicon-collapse-open");
                    break;
                case IconTypes.BigCollapseClose:
                    span.AddCssClass("tn-bigicon-collapse-close");
                    break;
                case IconTypes.BigDownLoad:
                    span.AddCssClass("tn-bigicon-download");
                    break;
                case IconTypes.BigUpLoad:
                    span.AddCssClass("tn-bigicon-upLoad");
                    break;
                case IconTypes.BigExpand:
                    span.AddCssClass("tn-bigicon-expand");
                    break;
                case IconTypes.BigFold:
                    span.AddCssClass("tn-bigicon-fold");
                    break;
                case IconTypes.BigSlideNext:
                    span.AddCssClass("tn-bigicon-slide-next");
                    break;
                case IconTypes.BigSlidePrev:
                    span.AddCssClass("tn-bigicon-slide-prev");
                    break;
                case IconTypes.BigFirst:
                    span.AddCssClass("tn-bigicon-first");
                    break;
                case IconTypes.BigLast:
                    span.AddCssClass("tn-bigicon-last");
                    break;
                case IconTypes.BigWrite:
                    span.AddCssClass("tn-bigicon-write");
                    break;
                case IconTypes.BigUpdate:
                    span.AddCssClass("tn-bigicon-update");
                    break;
                case IconTypes.BigSet:
                    span.AddCssClass("tn-bigicon-set");
                    break;
                case IconTypes.BigConfig:
                    span.AddCssClass("tn-bigicon-config");
                    break;
                case IconTypes.BigAdd:
                    span.AddCssClass("tn-bigicon-add");
                    break;
                case IconTypes.BigCross:
                    span.AddCssClass("tn-bigicon-cross");
                    break;
                case IconTypes.BigRotateLeft:
                    span.AddCssClass("tn-bigicon-rotate-left");
                    break;
                case IconTypes.BigRotateRight:
                    span.AddCssClass("tn-bigicon-rotate-right");
                    break;
                case IconTypes.BigEnlarge:
                    span.AddCssClass("tn-bigicon-enlarge");
                    break;
                case IconTypes.BigEmail:
                    span.AddCssClass("tn-bigicon-email");
                    break;
                case IconTypes.BigTop:
                    span.AddCssClass("tn-bigicon-top");
                    break;
                case IconTypes.BigLock:
                    span.AddCssClass("tn-bigicon-lock");
                    break;
                case IconTypes.BigShare:
                    span.AddCssClass("tn-bigicon-share");
                    break;
                case IconTypes.BigBubble:
                    span.AddCssClass("tn-bigicon-bubble");
                    break;
                case IconTypes.BigFavorite:
                    span.AddCssClass("tn-bigicon-favorite");
                    break;
                case IconTypes.BigQuotesBefore:
                    span.AddCssClass("tn-bigicon-quotes-before");
                    break;
                case IconTypes.BigQuotesAfter:
                    span.AddCssClass("tn-bigicon-quotes-after");
                    break;
                case IconTypes.BigTopic:
                    span.AddCssClass("tn-bigicon-topic");
                    break;
                case IconTypes.BigUser:
                    span.AddCssClass("tn-bigicon-user");
                    break;
                case IconTypes.BigGroup:
                    span.AddCssClass("tn-bigicon-group");
                    break;
                case IconTypes.BigChain:
                    span.AddCssClass("tn-bigicon-chain");
                    break;
                case IconTypes.BigZoom:
                    span.AddCssClass("tn-bigicon-zoom");
                    break;
                case IconTypes.BigAlert:
                    span.AddCssClass("tn-bigicon-alert");
                    break;
                case IconTypes.BigExclamation:
                    span.AddCssClass("tn-bigicon-exclamation");
                    break;
                case IconTypes.BigAcceptCircle:
                    span.AddCssClass("tn-bigicon-accept-circle");
                    break;
                case IconTypes.BigCrossCircle:
                    span.AddCssClass("tn-bigicon-cross-circle");
                    break;
                case IconTypes.BigLogout:
                    span.AddCssClass("tn-bigicon-logout");
                    break;
                case IconTypes.BigHome:
                    span.AddCssClass("tn-bigicon-home");
                    break;
                case IconTypes.BigEmotion:
                    span.AddCssClass("tn-bigicon-emotion");
                    break;
                case IconTypes.BigFolder:
                    span.AddCssClass("tn-bigicon-folder");
                    break;
                case IconTypes.BigMoive:
                    span.AddCssClass("tn-bigicon-moive");
                    break;
                case IconTypes.BigPicture:
                    span.AddCssClass("tn-bigicon-picture");
                    break;
                case IconTypes.BigAlbum:
                    span.AddCssClass("tn-bigicon-album");
                    break;
                case IconTypes.BigSound:
                    span.AddCssClass("tn-bigicon-sound");
                    break;
                case IconTypes.BigBlog:
                    span.AddCssClass("tn-bigicon-blog");
                    break;
                case IconTypes.BigEvent:
                    span.AddCssClass("tn-bigicon-event");
                    break;
                case IconTypes.BigVote:
                    span.AddCssClass("tn-bigicon-vote");
                    break;
                case IconTypes.BigNews:
                    span.AddCssClass("tn-bigicon-news");
                    break;
                case IconTypes.BigJob:
                    span.AddCssClass("tn-bigicon-job");
                    break;
                case IconTypes.BigApp:
                    span.AddCssClass("tn-bigicon-app");
                    break;
                case IconTypes.BigAt:
                    span.AddCssClass("tn-bigicon-at");
                    break;
                case IconTypes.BigPlay:
                    span.AddCssClass("tn-bigicon-play");
                    break;
                case IconTypes.BigPause:
                    span.AddCssClass("tn-bigicon-pause");
                    break;
                case IconTypes.BigDiscovery:
                    span.AddCssClass("tn-bigicon-discovery");
                    break;
                case IconTypes.BigSkin:
                    span.AddCssClass("tn-bigicon-skin");
                    break;
                case IconTypes.BigAddPicture:
                    span.AddCssClass("tn-bigicon-add-picture");
                    break;
                case IconTypes.BigCamera:
                    span.AddCssClass("tn-bigicon-camera");
                    break;
                case IconTypes.BigMusic:
                    span.AddCssClass("tn-bigicon-music");
                    break;
                case IconTypes.BigAsk:
                    span.AddCssClass("tn-bigicon-ask");
                    break;
                case IconTypes.BigBar:
                    span.AddCssClass("tn-bigicon-bar");
                    break;
                case IconTypes.BigPointMall:
                    span.AddCssClass("tn-bigicon-pointmall");
                    break;

                //64*64_large
                case IconTypes.LargeLock:
                    span.AddCssClass("tn-largeicon-lock");
                    break;
                case IconTypes.LargeUser:
                    span.AddCssClass("tn-largeicon-user");
                    break;
                case IconTypes.LargeAlert:
                    span.AddCssClass("tn-largeicon-alert");
                    break;
                case IconTypes.LargeExclamation:
                    span.AddCssClass("tn-largeicon-exclamation");
                    break;
                case IconTypes.LargeCrossCircle:
                    span.AddCssClass("tn-largeicon-cross-circle");
                    break;
                case IconTypes.LargeAcceptCircle:
                    span.AddCssClass("tn-largeicon-accept-circle");
                    break;
                default:
                    break;
            }
            span.AddCssClass("tn-icon");

            if (!string.IsNullOrEmpty(title))
                span.MergeAttribute("title", title);
            if (htmlAttributes != null)
            {
                RouteValueDictionary attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                if (attributes.Any(n => n.Key.ToLower() == "class"))
                    span.AddCssClass(attributes.Single(n => n.Key.ToLower() == "class").Value.ToString());
                span.MergeAttributes(attributes, false);
            }

            return MvcHtmlString.Create(span.ToString(TagRenderMode.Normal));
        }

        #endregion

        #region 按钮

        /// <summary>
        /// 链接按钮
        /// </summary>
        /// <param name="htmlHelper">被扩展的HtmlHelper实例</param>
        /// <param name="text">链接文字</param>
        /// <param name="url">链接地址</param>
        /// <param name="highlightStyle">高亮显示类型</param>
        /// <param name="size">按钮尺寸</param>
        /// <param name="iconType">包含图标的类型</param>
        /// <param name="textIconLayout">文字图标排列顺序</param>
        /// <param name="htmlAttributes">按钮的html属性</param>  
        /// <returns>链接的html代码</returns>
        public static MvcHtmlString LinkButton(this HtmlHelper htmlHelper, string text, string url,
                                                                          HighlightStyles highlightStyle = HighlightStyles.Default,
                                                                          ButtonSizes size = ButtonSizes.Default,
                                                                          IconTypes? iconType = null,
                                                                          TextIconLayout textIconLayout = TextIconLayout.IconText,
                                                                          object htmlAttributes = null
                                                                          )
        {
            return Button(htmlHelper, text, ButtonTypes.Link, highlightStyle, size, iconType, textIconLayout, url, htmlAttributes);
        }

        /// <summary>
        /// 输出按钮
        /// </summary>
        /// <param name="htmlHelper">被扩展的HtmlHelper实例</param>
        /// <param name="text">文本内容</param>
        /// <param name="url">点击跳转向的地址</param>
        /// <param name="iconType">图标类型</param>
        /// <param name="textIconLayout">图标和文本排列顺序</param>
        /// <param name="buttonType">按钮类型</param>
        /// <param name="size">按钮大小</param>
        /// <param name="highlightStyle">高亮显示类型</param>
        /// <param name="htmlAttributes">按钮Html属性集合</param>
        /// <returns>按钮的html代码</returns>
        public static MvcHtmlString Button(this HtmlHelper htmlHelper, string text, ButtonTypes buttonType,
                                                                    HighlightStyles highlightStyle = HighlightStyles.Default,
                                                                    ButtonSizes size = ButtonSizes.Default,
                                                                    IconTypes? iconType = null,
                                                                    TextIconLayout textIconLayout = TextIconLayout.IconText,
                                                                    string url = null,
                                                                   object htmlAttributes = null
                                                                  )
        {
            return Button(htmlHelper, text, buttonType, highlightStyle, size, iconType, textIconLayout, url, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// 输出按钮
        /// </summary>
        /// <param name="htmlHelper">被扩展的HtmlHelper实例</param>
        /// <param name="text">文本内容</param>
        /// <param name="url">点击跳转向的地址</param>
        /// <param name="iconType">图标类型</param>
        /// <param name="textIconLayout">图标和文本排列顺序</param>
        /// <param name="buttonType">按钮类型</param>
        /// <param name="size">按钮大小</param>
        /// <param name="highlightStyle">高亮显示类型</param>
        /// <param name="htmlAttributes">按钮Html属性集合</param>
        /// <returns>按钮的html代码</returns>
        private static MvcHtmlString Button(this HtmlHelper htmlHelper, string text, ButtonTypes buttonType,
                                                                    HighlightStyles highlightStyle = HighlightStyles.Default,
                                                                    ButtonSizes size = ButtonSizes.Default,
                                                                    IconTypes? iconType = null,
                                                                    TextIconLayout textIconLayout = TextIconLayout.IconText,
                                                                    string url = null,
                                                                   RouteValueDictionary htmlAttributes = null
                                                                  )
        {
            TagBuilder builder = null;
            if (buttonType == ButtonTypes.Link)
            {
                builder = new TagBuilder("a");

                if (!string.IsNullOrEmpty(url))
                    builder.MergeAttribute("href", WebUtility.ResolveUrl(url));
                if (htmlAttributes != null)
                {
                    if (htmlAttributes.Any(n => n.Key.ToLower() == "href"))
                        builder.MergeAttribute("href", htmlAttributes.Single(n => n.Key.ToLower() == "href").Value.ToString());
                }
                builder.MergeAttribute("href", "javascript:;", false);
            }
            else
            {
                builder = new TagBuilder("Button");
                if (!string.IsNullOrEmpty(url))
                    builder.MergeAttribute("url", url);

                switch (buttonType)
                {
                    case ButtonTypes.Submit:
                        builder.MergeAttribute("type", "submit");
                        break;
                    case ButtonTypes.Cancel:
                        builder.MergeAttribute("type", "button");
                        break;
                    case ButtonTypes.Reset:
                        builder.MergeAttribute("type", "reset");
                        break;
                    case ButtonTypes.Button:
                    default:
                        builder.MergeAttribute("type", "button");
                        break;
                }
            }
            builder.AddCssClass("tn-button tn-corner-all");

            //设置按钮内容
            if (iconType == null && string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("text 或 iconType至少有一个不为 null");
            }
            //设置图标
            if (iconType != null)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    if (textIconLayout == TextIconLayout.IconText)
                        builder.AddCssClass("tn-button-text-icon-primary");
                    else
                        builder.AddCssClass("tn-button-text-icon-secondary");
                }
                else
                {
                    builder.AddCssClass("tn-button-icon-only");
                    text = "&nbsp;";
                }
                builder.InnerHtml = Icon(htmlHelper, iconType.Value).ToString();
            }
            else
                builder.AddCssClass("tn-button-text-only");

            string buttonText = "<span class=\"tn-button-text\">" + text + "</span>";
            if (textIconLayout == TextIconLayout.IconText)
                builder.InnerHtml += buttonText;
            else
                builder.InnerHtml = buttonText + builder.InnerHtml;

            //设置按钮大小
            if (size == ButtonSizes.Large)
                builder.AddCssClass("tn-button-large");

            //设置按钮高亮类型
            switch (highlightStyle)
            {
                case HighlightStyles.Primary:
                    builder.AddCssClass("tn-button-primary");
                    break;
                case HighlightStyles.Secondary:
                    builder.AddCssClass("tn-button-secondary");
                    break;
                case HighlightStyles.Lite:
                    builder.AddCssClass("tn-button-lite");
                    break;
                case HighlightStyles.Hollow:
                    builder.AddCssClass("tn-button-hollow");
                    break;
                case HighlightStyles.Default:
                default:
                    builder.AddCssClass("tn-button-default");
                    break;
            }

            if (htmlAttributes != null)
            {
                if (htmlAttributes.Any(n => n.Key.ToLower() == "class"))
                    builder.AddCssClass(htmlAttributes.Single(n => n.Key.ToLower() == "class").Value.ToString());
            }
            builder.MergeAttributes(htmlAttributes);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        #endregion
    }
    public enum ButtonSizes
    {
        /// <summary>
        /// 默认大小
        /// </summary>
        Default,
        /// <summary>
        /// 大按钮
        /// </summary>
        Large
    }

    public enum HighlightStyles
    {
        /// <summary>
        /// 默认高亮
        /// 淡蓝色
        /// </summary>
        Default,
        /// <summary>
        /// 主流高亮
        /// 深蓝色，主要用于提交等需要突出显示的按钮
        /// </summary>
        Primary,
        /// <summary>
        /// 非主流高亮
        /// 灰色，主要用于取消等不需要突出显示的按钮
        /// </summary>
        Secondary,
        /// <summary>
        /// 最弱的高亮效果
        /// 不显示背景色，只有鼠标移上去才会显示背景色
        /// </summary>
        Lite,
        /// <summary>
        /// 镂空效果(无底色）
        /// 默认只显示边框色，只有鼠标移上去才会显示背景色
        /// </summary>
        Hollow
    }
    public enum TextIconLayout
    {
        /// <summary>
        /// 图标在前，文本在后
        /// </summary>
        IconText,
        /// <summary>
        /// 文本在前，图标在后
        /// </summary>
        TextIcon
    }

    public enum ButtonTypes
    {
        /// <summary>
        /// 输入按钮
        /// </summary>
        Button,
        /// <summary>
        /// 重置按钮
        /// </summary>
        Reset,
        /// <summary>
        /// 链接按钮
        /// </summary>
        Link,
        /// <summary>
        /// 提交按钮
        /// </summary>
        Submit,
        /// <summary>
        /// 取消按钮
        /// </summary>
        Cancel
    }
     /// <summary>
    /// 图标类型
    /// </summary>
    public enum IconTypes
    {
        //16*16
        /// <summary>
        /// 上箭头
        /// </summary>
        TriangleUp,
        /// <summary>
        /// 右箭头
        /// </summary>
        TriangleRight,
        /// <summary>
        /// 下
        /// </summary>
        TriangleDown,
        /// <summary>
        /// 左
        /// </summary>
        TriangleLeft,
        /// <summary>
        /// 展开
        /// </summary>
        CollapseOpen,
        /// <summary>
        /// 收起
        /// </summary>
        CollapseClose,
        /// <summary>
        /// 下载
        /// </summary>
        Download,
        /// <summary>
        /// 上传
        /// </summary>
        Upload,
        /// <summary>
        /// 向下、展开
        /// </summary>
        Expand,
        /// <summary>
        /// 向上、收起
        /// </summary>
        Fold,
        /// <summary>
        /// 向后
        /// </summary>
        SlideNext,
        /// <summary>
        /// 向前
        /// </summary>
        SlidePrev,
        /// <summary>
        /// 最先的
        /// </summary>
        First,
        /// <summary>
        /// 最后的
        /// </summary>
        Last,
        /// <summary>
        /// 添加、新建
        /// </summary>
        Add,
        /// <summary>
        /// 编辑、描述
        /// </summary>
        Write,
        /// <summary>
        /// 更新、重建
        /// </summary>
        Update,
        /// <summary>
        /// 设置
        /// </summary>
        Set,
        /// <summary>
        /// 配置
        /// </summary>
        Config,
        /// <summary>
        /// 删除、关闭
        /// </summary>
        Cross,
        /// <summary>
        /// 通过、允许、同意
        /// </summary>
        Accept,
        /// <summary>
        /// 左旋转
        /// </summary>
        RotateLeft,
        /// <summary>
        /// 右旋转
        /// </summary>
        RotateRight,
        /// <summary>
        /// 扩大
        /// </summary>
        Enlarge,
        /// <summary>
        /// 学校
        /// </summary>
        School,
        /// <summary>
        /// 相互关注
        /// </summary>
        Friendly,
        /// <summary>
        /// 悄悄关注
        /// </summary>
        Sneak,
        /// <summary>
        /// 转发
        /// </summary>
        Forwardc,
        /// <summary>
        /// 不通过、否定、拒绝、阻止
        /// </summary>
        Stop,
        ///// <summary>
        ///// 设置
        ///// </summary>
        //Set,
        ///// <summary>
        ///// 配置
        ///// </summary>
        //Config,
        /// <summary>
        /// 精华
        /// </summary>
        Elite,
        /// <summary>
        /// 消息，未读
        /// </summary>
        Email,
        /// <summary>
        /// 消息，已读
        /// </summary>
        EmailOpen,
        /// <summary>
        /// 置顶
        /// </summary>
        Top,
        /// <summary>
        /// 推荐
        /// </summary>
        Flag,
        /// <summary>
        /// 锁定、私有
        /// </summary>
        Lock,
        /// <summary>
        /// 密钥访问
        /// </summary>
        Key,
        /// <summary>
        /// 权限访问
        /// </summary>
        Limit,
        /// <summary>
        /// 积分、钱币
        /// </summary>
        Coins,
        /// <summary>
        /// 热的、急的
        /// </summary>
        Fire,
        /// <summary>
        /// 移动
        /// </summary>
        Move,
        /// <summary>
        /// 个人认证
        /// </summary>
        Approve,
        /// <summary>
        /// 浏览、查看
        /// </summary>
        View,
        /// <summary>
        /// 支持、顶
        /// </summary>
        ThumbUp,
        /// <summary>
        /// 反对、踩
        /// </summary>
        ThumbDown,
        /// <summary>
        /// 分享
        /// </summary>
        Share,
        /// <summary>
        /// 评论、留言
        /// </summary>
        Bubble,
        /// <summary>
        /// 收藏、喜爱 
        /// </summary>
        Favorite,
        /// <summary>
        /// 加星
        /// </summary>
        Star,
        /// <summary>
        /// 订阅
        /// </summary>
        Feed,
        /// <summary>
        /// 双引号、前
        /// </summary>
        QuotesBefore,
        /// <summary>
        /// 双引号、后
        /// </summary>
        QuotesAfter,
        /// <summary>
        /// 主题、话题
        /// </summary>
        Topic,
        /// <summary>
        /// 标签
        /// </summary>
        Label,
        /// <summary>
        /// 用户、好友、成员
        /// </summary>
        User,
        /// <summary>
        /// 添加好友
        /// </summary>
        UserAdd,
        /// <summary>
        /// 特许用户
        /// </summary>
        UserAllow,
        /// <summary>
        /// 阻止用户
        /// </summary>
        UserStop,
        /// <summary>
        /// 用户关系
        /// </summary>
        UserRelation,
        /// <summary>
        /// 用户头像
        /// </summary>
        UserAvatar,
        /// <summary>
        /// 邀请用户
        /// </summary>
        UserInvite, //
        /// <summary>
        /// 用户卡片
        /// </summary>
        UserCard,
        /// <summary>
        /// 群组
        /// </summary>
        Group,
        /// <summary>
        /// 链接
        /// </summary>
        Chain,
        /// <summary>
        /// 个性签名、钢笔
        /// </summary>
        Pen,
        /// <summary>
        /// 男
        /// </summary>
        Creator,
        /// <summary>
        /// 女
        /// </summary>
        Manager,
        /// <summary>
        /// 列表浏览
        /// </summary>
        BrowseList,
        /// <summary>
        /// 详情浏览
        /// </summary>
        BrowseDetail,
        /// <summary>
        /// 中图、中块浏览
        /// </summary>
        BrowseMedium,
        /// <summary>
        /// 小图、小块浏览
        /// </summary>
        BrowseSmall,
        /// <summary>
        /// 幻灯浏览
        /// </summary>
        BrowseSlide,
        /// <summary>
        /// 页面装扮，布局调整
        /// </summary>
        Dress,
        /// <summary>
        /// 跳转
        /// </summary>
        Jump,
        /// <summary>
        /// 放大
        /// </summary>
        Zomm,
        /// <summary>
        /// 照片
        /// </summary>
        Camera,
        /// <summary>
        /// 日期指示
        /// </summary>
        Calendar,
        /// <summary>
        /// 颜色
        /// </summary>
        Color,
        /// <summary>
        /// 创建人、高级管理员
        /// </summary>
        Admin,
        /// <summary>
        /// 管理员、副管理员
        /// </summary>
        Auadmin,
        /// <summary>
        /// 女
        /// </summary>
        Female,
        /// <summary>
        /// 男
        /// </summary>
        Male,
        /// <summary>
        /// //视频
        /// </summary>
        Movie,
        /// <summary>
        /// 声音
        /// </summary>
        Sound,
        /// <summary>
        /// 音乐
        /// </summary>
        Music,
        /// <summary>
        /// 皮肤
        /// </summary>
        Skin,
        /// <summary>
        /// 博客
        /// </summary>
        Blog,
        /// <summary>
        /// 档案
        /// </summary>
        Archive,
        /// <summary>
        /// 论坛、讨论组
        /// </summary>
        Forum,
        /// <summary>
        /// 投票
        /// </summary>
        Vote,
        /// <summary>
        /// 新闻
        /// </summary>
        News,
        /// <summary>
        /// 资讯
        /// </summary>
        Cms,
        /// <summary>
        /// 求职、招聘、职位、经理
        /// </summary>
        Job,
        /// <summary>
        /// 互联网
        /// </summary>
        World,
        /// <summary>
        /// 主页
        /// </summary>
        Home,
        /// <summary>
        /// 疑问
        /// </summary>
        Question,
        /// <summary>
        /// 通知、消息
        /// </summary>
        Notice,
        /// <summary>
        /// 电梯、直达
        /// </summary>
        Escalator,
        /// <summary>
        /// 警告
        /// </summary>
        Alert,
        /// <summary>
        /// 提示
        /// </summary>
        Exclamation,
        /// <summary>
        /// 错误
        /// </summary>
        CrossCircle,
        /// <summary>
        /// 正确
        /// </summary>
        AcceptCircle,
        /// <summary>
        /// 申请
        /// </summary>
        Apply,
        /// <summary>
        /// 注销
        /// </summary>
        Logout,
        /// <summary>
        /// 加入
        /// </summary>
        Join,
        /// <summary>
        /// 退出
        /// </summary>
        Quit,
        /// <summary>
        /// 表情
        /// </summary>
        Emotion,
        /// <summary>
        /// 附件
        /// </summary>
        PaperClip,
        /// <summary>
        /// 文件
        /// </summary>
        Folder,
        /// <summary>
        /// 相册
        /// </summary>
        Album,
        /// <summary>
        /// 活动
        /// </summary>
        Event,
        /// <summary>
        /// 搜索
        /// </summary>
        Find,
        /// <summary>
        /// 图片
        /// </summary>
        Picture,
        ///// <summary>
        ///// 文章
        ///// </summary>
        //Archive,
        ///// <summary>
        ///// 疑问
        ///// </summary>
        //Question,
        ///// <summary>
        ///// 货币
        ///// </summary>
        //Coins,

        ///// <summary>
        ///// 主题
        ///// </summary>
        //Topic,
        ///// <summary>
        ///// 热点主题
        ///// </summary>
        //Fire,
        ///// <summary>
        ///// 引用
        ///// </summary>
        //QuotesBefore,
        ///// <summary>
        ///// 颜色
        ///// </summary>
        //Color,
        /// <summary>
        /// 应用
        /// </summary>
        App,
        /// <summary>
        /// 招贴、交易、买卖、市场
        /// </summary>
        Market,
        /// <summary>
        /// 问答
        /// </summary>
        Answer,
        /// <summary>
        /// 微博
        /// </summary>
        Microblog,
        /// <summary>
        /// 关于、提及
        /// </summary>
        At,
        /// <summary>
        /// 播放
        /// </summary>
        Play,
        /// <summary>
        /// 暂停
        /// </summary>
        Pause,
        /// <summary>
        /// 探索、发现
        /// </summary>
        Discovery,
        /// <summary>
        /// 礼品
        /// </summary>
        Gift,
        /// <summary>
        /// 功能(常用)
        /// </summary>
        Function,
        /// <summary>
        /// 地图(结构图)
        /// </summary>
        Chart,
        /// <summary>
        /// 时钟(最近访问)
        /// </summary>
        Clock,
        /// <summary>
        /// 排队(待处理)
        /// </summary>
        Pending,
        /// <summary>
        /// 数据表
        /// </summary>
        Datasheet,
        /// <summary>
        /// 系统信息
        /// </summary>
        System,
        /// <summary>
        /// 产品信息
        /// </summary>
        Product,
        /// <summary>
        /// 新增照片
        /// </summary>
        AddPicture,
        /// <summary>
        /// 封禁
        /// </summary>
        Banned,
        /// <summary>
        /// 管制
        /// </summary>
        Moderated,
        /// <summary>
        /// 问答
        /// </summary>
        Ask,
        /// <summary>
        /// 贴吧
        /// </summary>
        Bar,
        /// <summary>
        /// 积分商城
        /// </summary>
        PointMall,
        Wiki,
        //16*16_small
        /// <summary>
        /// small上箭头
        /// </summary>
        SmallTriangleUp,
        /// <summary>
        /// small右箭头
        /// </summary>
        SmallTriangleRight,
        /// <summary>
        /// small下箭头
        /// </summary>
        SmallTriangleDown,
        /// <summary>
        /// small左箭头
        /// </summary>
        SmallTriangleLeft,
        /// <summary>
        /// small展开
        /// </summary>
        SmallCollapseOpen,
        /// <summary>
        /// small收起
        /// </summary>
        SmallCollapseClose,
        /// <summary>
        /// small下载
        /// </summary>
        SmallDownload,
        ///<summary>
        /// small上传
        /// </summary>
        SmallUpload,
        ///<summary>
        /// small编辑、描述
        /// </summary>
        SmallWrite,
        /// <summary>
        /// small更新、重建
        /// </summary>
        SmallUpdate,
        /// <summary>
        /// small设置
        /// </summary>
        SmallSet,
        /// <summary>
        /// small配置
        /// </summary>
        SmallConfig,
        /// <summary>
        /// small添加、新建
        /// </summary>
        SmallAdd,
        /// <summary>
        /// small删除、关闭
        /// </summary>
        SmallCross,
        /// <summary>
        /// small通过、允许、同意
        /// </summary>
        SmallAccept,
        /// <summary>
        /// small不通过、否定、拒绝、阻止
        /// </summary>
        SmallStop,
        /// <summary>
        /// small向下、展开
        /// </summary>
        SmallExpand,
        /// <summary>
        /// small向上、收起
        /// </summary>
        SmallFold,
        /// <summary>
        /// small向后
        /// </summary>
        SmallSlideNext,
        /// <summary>
        /// small向前
        /// </summary>
        SmallSlidePrev,
        /// <summary>
        /// small最先的
        /// </summary>
        SmallSlideFirst,
        /// <summary>
        /// small最后的
        /// </summary>
        SmallSlideLast,
        /// <summary>
        /// small置顶
        /// </summary>
        SmallTop,
        /// <summary>
        /// small微博
        /// </summary>
        SmallMicroblog,
        /// <summary>
        /// small左旋转
        /// </summary>
        SmallRotateLeft,
        /// <summary>
        /// small右旋转
        /// </summary>
        SmallRotateRight,
        /// <summary>
        /// small扩大
        /// </summary>
        SmallEnlarge,
        /// <summary>
        /// small标签
        /// </summary>
        SmallLabel,
        /// <summary>
        /// small搜索、查找
        /// </summary>
        SmallFind,
        /// <summary>
        /// small警告
        /// </summary>
        SmallAlert,
        /// <summary>
        /// small精华
        /// </summary>
        SmallElite,
        /// <summary>
        /// small相互关注
        /// </summary>
        SmallFriendly,
        /// <summary>
        /// small悄悄关注
        /// </summary>
        SmallSneak,
        /// <summary>
        /// small女
        /// </summary>
        SmallFemale,
        /// <summary>
        /// small男
        /// </summary>
        SmallMale,
        /// <summary>
        /// smallAsk
        /// </summary>
        SmallAsk,
        /// <summary>
        /// smallBar
        /// </summary>
        SmallBar,
        /// <summary>
        /// pointMall
        /// </summary>
        SmallPointMall,
        /// <summary>
        /// smallGroup
        /// </summary>
        SmallGroup,
        //32*32_big
        /// <summary>
        /// big上箭头
        /// </summary>
        BigTriangleUp,
        ///<summary>
        /// big右箭头
        /// </summary>
        BigTriangleRight,
        /// <summary>
        /// big下箭头
        /// </summary>
        BigTriangleDown,
        /// <summary>
        /// big左箭头
        /// </summary>
        BigTriangleLeft,
        /// <summary>
        /// big展开
        /// </summary>
        BigCollapseOpen,
        /// <summary>
        /// big收起
        /// </summary>
        BigCollapseClose,
        /// <summary>
        /// big下载
        /// </summary>
        BigDownLoad,
        /// <summary>
        /// big上传
        /// </summary>
        BigUpLoad,
        /// <summary>
        /// big向下、展开
        /// </summary>
        BigExpand,
        /// <summary>
        /// big向上、收起
        /// </summary>
        BigFold,
        /// <summary>
        /// big向后
        /// </summary>
        BigSlideNext,
        /// <summary>
        /// big向前
        /// </summary>
        BigSlidePrev,
        /// <summary>
        /// big最先的
        /// </summary>
        BigFirst,
        /// <summary>
        /// big最后的
        /// </summary>
        BigLast,
        /// <summary>
        /// big编辑、描述
        /// </summary>
        BigWrite,
        /// <summary>
        /// big更新、重建
        /// </summary>
        BigUpdate,
        /// <summary>
        /// big设置
        /// </summary>
        BigSet,
        /// <summary>
        /// big配置
        /// </summary>
        BigConfig,
        /// <summary>
        /// big添加、新建
        /// </summary>
        BigAdd,
        /// <summary>
        /// big删除、关闭
        /// </summary>
        BigCross,
        /// <summary>
        /// big左旋转
        /// </summary>
        BigRotateLeft,
        /// <summary>
        /// big右旋转
        /// </summary>
        BigRotateRight,
        /// <summary>
        /// big扩大
        /// </summary>
        BigEnlarge,
        /// <summary>
        /// big消息、未读
        /// </summary>
        BigEmail,
        /// <summary>
        /// big置顶
        /// </summary>
        BigTop,
        /// <summary>
        /// big锁定、私有
        /// </summary>
        BigLock,
        /// <summary>
        /// big分享
        /// </summary>
        BigShare,
        /// <summary>
        /// big评论、留言
        /// </summary>
        BigBubble,
        /// <summary>
        /// big收藏、喜爱
        /// </summary>
        BigFavorite,
        /// <summary>
        /// big双引号、前
        /// </summary>
        BigQuotesBefore,
        /// <summary>
        /// big双引号、后
        /// </summary>
        BigQuotesAfter,
        /// <summary>
        /// big主题、话题
        /// </summary>
        BigTopic,
        /// <summary>
        /// big用户、好友、成员
        /// </summary>
        BigUser,
        /// <summary>
        /// big群组
        /// </summary>
        BigGroup,
        /// <summary>
        /// big链接
        /// </summary>
        BigChain,
        /// <summary>
        /// big放大
        /// </summary>
        BigZoom,
        /// <summary>
        /// big警告
        /// </summary>
        BigAlert,
        /// <summary>
        /// big提示
        /// </summary>
        BigExclamation,
        /// <summary>
        /// big错误
        /// </summary>
        BigCrossCircle,
        /// <summary>
        /// big正确
        /// </summary>
        BigAcceptCircle,
        /// <summary>
        /// big注销、退出
        /// </summary>
        BigLogout,
        /// <summary>
        /// big主页
        /// </summary>
        BigHome,
        /// <summary>
        /// big表情
        /// </summary>
        BigEmotion,
        /// <summary>
        /// big文件
        /// </summary>
        BigFolder,
        /// <summary>
        /// big视频
        /// </summary>
        BigMoive,
        /// <summary>
        /// big图片
        /// </summary>
        BigPicture,
        /// <summary>
        /// big相册
        /// </summary>
        BigAlbum,
        /// <summary>
        /// big声音
        /// </summary>
        BigSound,
        /// <summary>
        /// big博客
        /// </summary>
        BigBlog,
        /// <summary>
        /// big活动
        /// </summary>
        BigEvent,
        /// <summary>
        /// big投票
        /// </summary>
        BigVote,
        ///  <summary>
        /// big新闻、资讯
        /// </summary>
        BigNews,
        ///  <summary>
        /// big求职、招聘、职位、经理
        /// </summary>
        BigJob,
        ///  <summary>
        /// big应用程序
        /// </summary>
        BigApp,
        ///  <summary>
        /// big关于、提及
        /// </summary>
        BigAt,
        ///  <summary>
        /// big播放
        /// </summary>
        BigPlay,
        ///  <summary>
        /// big暂停
        /// </summary>
        BigPause,
        ///  <summary>
        /// big探索、发现
        /// </summary>
        BigDiscovery,
        ///  <summary>
        /// big皮肤
        /// </summary>
        BigSkin,
        ///  <summary>
        /// big添加照片
        /// </summary>
        BigAddPicture,
        ///  <summary>
        /// big照片
        /// </summary>
        BigCamera,
        ///  <summary>
        /// big音乐
        /// </summary>
        BigMusic,
        /// <summary>
        /// bigAsk
        /// </summary>
        BigAsk,
        /// <summary>
        /// BigBar
        /// </summary>
        BigBar,
        /// <summary>
        /// PointMall
        /// </summary>
        BigPointMall,
        //64*64_large
        /// <summary>
        /// large锁定
        /// </summary>
        LargeLock,
        /// <summary>
        /// large用户
        /// </summary>
        LargeUser,
        /// <summary>
        /// large警告
        /// </summary>
        LargeAlert,
        /// <summary>
        /// large提示
        /// </summary>
        LargeExclamation,
        /// <summary>
        /// large锁定
        /// </summary>
        LargeCrossCircle,
        /// <summary>
        /// large锁定
        /// </summary>
        LargeAcceptCircle
    }
}
