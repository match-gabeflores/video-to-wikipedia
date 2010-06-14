// Type: FlickrNet.Flickr
// Assembly: FlickrNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=2491df59efa5d132
// Assembly location: C:\Users\w3stfa11\Documents\Visual Studio 2010\Projects\video-to-wikipedia.git\Video-to-Wikipedia\bin\FlickrNet.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;

namespace FlickrNet
{
    public class Flickr
    {
        public Flickr();
        public Flickr(string apiKey);
        public Flickr(string apiKey, string sharedSecret);
        public Flickr(string apiKey, string sharedSecret, string token);
        public Uri BaseUri { get; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string AuthToken { get; set; }
        public static bool CacheDisabled { get; set; }
        public static TimeSpan CacheTimeout { get; set; }
        public static string CacheLocation { get; set; }
        public static long CacheSizeLimit { get; set; }
        public static SupportedService DefaultService { get; set; }
        public SupportedService CurrentService { get; set; }
        public int HttpTimeout { get; set; }
        public bool IsAuthenticated { get; }
        public string LastResponse { get; }
        public string LastRequest { get; }
        public WebProxy Proxy { get; set; }
        public InstitutionCollection CommonsGetInstitutions();
        public void GalleriesAddPhoto(string galleryId, string photoId);
        public void GalleriesAddPhoto(string galleryId, string photoId, string comment);
        public void GalleriesCreate(string title, string description);
        public void GalleriesCreate(string title, string description, string primaryPhotoId);
        public void GalleriesEditMeta(string galleryId, string title);
        public void GalleriesEditMeta(string galleryId, string title, string description);
        public void GalleriesEditPhoto(string galleryId, string photoId, string comment);
        public void GalleriesEditPhotos(string galleryId, string primaryPhotoId, IEnumerable<string> photoIds);
        public Gallery GalleriesGetInfo(string galleryId);
        public GalleryCollection GalleriesGetList();
        public GalleryCollection GalleriesGetList(int page, int perPage);
        public GalleryCollection GalleriesGetList(string userId);
        public GalleryCollection GalleriesGetList(string userId, int page, int perPage);
        public GalleryCollection GalleriesGetListForPhoto(string photoId);
        public GalleryCollection GalleriesGetListForPhoto(string photoId, int page, int perPage);
        public GalleryPhotoCollection GalleriesGetPhotos(string galleryId);
        public GalleryPhotoCollection GalleriesGetPhotos(string galleryId, PhotoSearchExtras extras);
        public NamespaceCollection MachineTagsGetNamespaces();
        public NamespaceCollection MachineTagsGetNamespaces(int page, int perPage);
        public NamespaceCollection MachineTagsGetNamespaces(string predicate);
        public NamespaceCollection MachineTagsGetNamespaces(string predicate, int page, int perPage);
        public PredicateCollection MachineTagsGetPredicates();
        public PredicateCollection MachineTagsGetPredicates(int page, int perPage);
        public PredicateCollection MachineTagsGetPredicates(string namespaceName);
        public PredicateCollection MachineTagsGetPredicates(string namespaceName, int page, int perPage);
        public PairCollection MachineTagsGetPairs();
        public PairCollection MachineTagsGetPairs(int page, int perPage);
        public PairCollection MachineTagsGetPairs(string namespaceName, string predicate);
        public PairCollection MachineTagsGetPairs(string namespaceName, string predicate, int page, int perPage);
        public FlickrNet.ValueCollection MachineTagsGetValues(string namespaceName, string predicate);

        public FlickrNet.ValueCollection MachineTagsGetValues(string namespaceName, string predicate, int page,
                                                              int perPage);

        public FlickrNet.ValueCollection MachineTagsGetRecentValues(DateTime addedSince);
        public FlickrNet.ValueCollection MachineTagsGetRecentValues(DateTime addedSince, int page, int perPage);
        public FlickrNet.ValueCollection MachineTagsGetRecentValues(string namespaceName, string predicate);

        public FlickrNet.ValueCollection MachineTagsGetRecentValues(string namespaceName, string predicate, int page,
                                                                    int perPage);

        public FlickrNet.ValueCollection MachineTagsGetRecentValues(string namespaceName, string predicate,
                                                                    DateTime addedSince, int page, int perPage);

        public void PhotosPeopleAdd(string photoId, string userId);

        public void PhotosPeopleAdd(string photoId, string userId, int? personX, int? personY, int? personWidth,
                                    int? personHeight);

        public void PhotosPeopleDelete(string photoId, string userId);
        public void PhotosPeopleDeleteCoords(string photoId, string userId);

        public void PhotosPeopleEditCoords(string photoId, string userId, int personX, int personY, int personWidth,
                                           int personHeight);

        public PhotoPersonCollection PhotosPeopleGetList(string photoId);
        public string UploadPicture(string fileName);
        public string UploadPicture(string fileName, string title);
        public string UploadPicture(string fileName, string title, string description);
        public string UploadPicture(string fileName, string title, string description, string tags);

        public string UploadPicture(string fileName, string title, string description, string tags, bool isPublic,
                                    bool isFamily, bool isFriend);

        public string UploadPicture(Stream stream, string fileName, string title, string description, string tags,
                                    bool isPublic, bool isFamily, bool isFriend, ContentType contentType,
                                    SafetyLevel safetyLevel, HiddenFromSearch hiddenFromSearch);

        public string ReplacePicture(string fullFileName, string photoId);
        public string ReplacePicture(Stream stream, string fileName, string photoId);
        public ActivityItemCollection ActivityUserPhotos();
        public ActivityItemCollection ActivityUserPhotos(int timePeriod, string timeType);
        public ActivityItemCollection ActivityUserComments(int page, int perPage);
        public BlogCollection BlogsGetList();
        public BlogServiceCollection BlogsGetServices();
        public void BlogsPostPhoto(string blogId, string photoId, string title, string description);
        public void BlogsPostPhoto(string blogId, string photoId, string title, string description, string blogPassword);
        public ContactCollection ContactsGetList();
        public ContactCollection ContactsGetList(int page, int perPage);
        public ContactCollection ContactsGetList(string filter);
        public ContactCollection ContactsGetList(string filter, int page, int perPage);
        public ContactCollection ContactsGetListRecentlyUploaded();
        public ContactCollection ContactsGetListRecentlyUploaded(string filter);
        public ContactCollection ContactsGetListRecentlyUploaded(DateTime dateLastUpdated);
        public ContactCollection ContactsGetListRecentlyUploaded(DateTime dateLastUpdated, string filter);
        public ContactCollection ContactsGetPublicList(string userId);
        public ContactCollection ContactsGetPublicList(string userId, int page, int perPage);
        public void FavoritesAdd(string photoId);
        public void FavoritesRemove(string photoId);
        public PhotoCollection FavoritesGetList();
        public PhotoCollection FavoritesGetList(int page, int perPage);
        public PhotoCollection FavoritesGetList(string userId);
        public PhotoCollection FavoritesGetList(string userId, int page, int perPage);
        public PhotoCollection FavoritesGetPublicList(string userId);

        public PhotoCollection FavoritesGetPublicList(string userId, DateTime minFavoriteDate, DateTime maxFavoriteDate,
                                                      PhotoSearchExtras extras, int page, int perPage);

        public GroupCategory GroupsBrowse();
        public GroupCategory GroupsBrowse(string catId);
        public GroupSearchResultCollection GroupsSearch(string text);
        public GroupSearchResultCollection GroupsSearch(string text, int page);
        public GroupSearchResultCollection GroupsSearch(string text, int page, int perPage);
        public GroupFullInfo GroupsGetInfo(string groupId);
        public MemberCollection GroupsMembersGetList(string groupId);
        public MemberCollection GroupsMembersGetList(string groupId, int page, int perPage, MemberTypes memberTypes);
        public void GroupsPoolsAdd(string photoId, string groupId);
        public Context GroupsPoolsGetContext(string photoId, string groupId);
        public void GroupsPoolsRemove(string photoId, string groupId);
        public MemberGroupInfoCollection GroupsPoolsGetGroups();
        public PhotoCollection GroupsPoolsGetPhotos(string groupId);
        public PhotoCollection GroupsPoolsGetPhotos(string groupId, string tags);
        public PhotoCollection GroupsPoolsGetPhotos(string groupId, int page, int perPage);
        public PhotoCollection GroupsPoolsGetPhotos(string groupId, string tags, int page, int perPage);

        public PhotoCollection GroupsPoolsGetPhotos(string groupId, string tags, string userId, PhotoSearchExtras extras,
                                                    int page, int perPage);

        public PhotoCollection InterestingnessGetList(PhotoSearchExtras extras, int page, int perPage);
        public PhotoCollection InterestingnessGetList(DateTime date);
        public PhotoCollection InterestingnessGetList();
        public PhotoCollection InterestingnessGetList(DateTime date, PhotoSearchExtras extras, int page, int perPage);

        public string PhotosNotesAdd(string photoId, int noteX, int noteY, int noteWidth, int noteHeight,
                                     string noteText);

        public void PhotosNotesEdit(string noteId, int noteX, int noteY, int noteWidth, int noteHeight, string noteText);
        public void PhotosNotesDelete(string noteId);
        public PhotoCommentCollection PhotosCommentsGetList(string photoId);
        public string PhotosCommentsAddComment(string photoId, string commentText);
        public void PhotosCommentsDeleteComment(string commentId);
        public void PhotosCommentsEditComment(string commentId, string commentText);
        public PhotoCollection PhotosCommentsGetRecentForContacts();
        public PhotoCollection PhotosCommentsGetRecentForContacts(int page, int perPage);

        public PhotoCollection PhotosCommentsGetRecentForContacts(DateTime dateLastComment, PhotoSearchExtras extras,
                                                                  int page, int perPage);

        public PhotoCollection PhotosCommentsGetRecentForContacts(DateTime dateLastComment, string[] contactsFilter,
                                                                  PhotoSearchExtras extras, int page, int perPage);

        public void PhotosetsAddPhoto(string photosetId, string photoId);
        public Photoset PhotosetsCreate(string title, string primaryPhotoId);
        public Photoset PhotosetsCreate(string title, string description, string primaryPhotoId);
        public void PhotosetsDelete(string photosetId);
        public void PhotosetsEditMeta(string photosetId, string title, string description);
        public void PhotosetsEditPhotos(string photosetId, string primaryPhotoId, string[] photoIds);
        public void PhotosetsEditPhotos(string photosetId, string primaryPhotoId, string photoIds);
        public Context PhotosetsGetContext(string photoId, string photosetId);
        public Photoset PhotosetsGetInfo(string photosetId);
        public PhotosetCollection PhotosetsGetList();
        public PhotosetCollection PhotosetsGetList(string userId);
        public PhotosetPhotoCollection PhotosetsGetPhotos(string photosetId);
        public PhotosetPhotoCollection PhotosetsGetPhotos(string photosetId, int page, int perPage);
        public PhotosetPhotoCollection PhotosetsGetPhotos(string photosetId, PrivacyFilter privacyFilter);

        public PhotosetPhotoCollection PhotosetsGetPhotos(string photosetId, PrivacyFilter privacyFilter, int page,
                                                          int perPage);

        public PhotosetPhotoCollection PhotosetsGetPhotos(string photosetId, PhotoSearchExtras extras);

        public PhotosetPhotoCollection PhotosetsGetPhotos(string photosetId, PhotoSearchExtras extras, int page,
                                                          int perPage);

        public PhotosetPhotoCollection PhotosetsGetPhotos(string photosetId, PhotoSearchExtras extras,
                                                          PrivacyFilter privacyFilter);

        public PhotosetPhotoCollection PhotosetsGetPhotos(string photosetId, PhotoSearchExtras extras,
                                                          PrivacyFilter privacyFilter, int page, int perPage);

        public PhotosetPhotoCollection PhotosetsGetPhotos(string photosetId, PhotoSearchExtras extras,
                                                          PrivacyFilter privacyFilter, int page, int perPage,
                                                          MediaType media);

        public void PhotosetsOrderSets(string[] photosetIds);
        public void PhotosetsOrderSets(string photosetIds);
        public void PhotosetsRemovePhoto(string photosetId, string photoId);
        public PhotosetCommentCollection PhotosetsCommentsGetList(string photosetId);
        public string PhotosetsCommentsAddComment(string photosetId, string commentText);
        public void PhotosetsCommentsDeleteComment(string commentId);
        public void PhotosetsCommentsEditComment(string commentId, string commentText);

        public void PhotosGeoBatchCorrectLocation(double latitude, double longitude, GeoAccuracy accuracy,
                                                  string placeId, string woeId);

        public void PhotosGeoCorrectLocation(string photoId, string placeId, string woeId);
        public PlaceInfo PhotosGeoGetLocation(string photoId);
        public void PhotosGeoSetContext(string photoId, GeoContext context);
        public void PhotosGeoSetLocation(string photoId, double latitude, double longitude);
        public void PhotosGeoSetLocation(string photoId, double latitude, double longitude, GeoAccuracy accuracy);

        public PhotoCollection PhotosGeoPhotosForLocation(double latitude, double longitude, GeoAccuracy accuracy,
                                                          PhotoSearchExtras extras, int perPage, int page);

        public void PhotosGeoRemoveLocation(string photoId);
        public PhotoCollection PhotosGetWithoutGeoData();
        public PhotoCollection PhotosGetWithoutGeoData(PartialSearchOptions options);

        [Obsolete("Use the PartialSearchOptions instead")]
        public PhotoCollection PhotosGetWithoutGeoData(PhotoSearchOptions options);

        public PhotoCollection PhotosGetWithGeoData();

        [Obsolete("Use the new PartialSearchOptions instead")]
        public PhotoCollection PhotosGetWithGeoData(PhotoSearchOptions options);

        public PhotoCollection PhotosGetWithGeoData(PartialSearchOptions options);
        public GeoPermissions PhotosGeoGetPerms(string photoId);
        public void PhotosGeoSetPerms(string photoId, bool isPublic, bool isContact, bool isFamily, bool isFriend);
        public void PhotosTransformRotate(string photoId, int degrees);
        public TicketCollection PhotosUploadCheckTickets(string[] tickets);
        public ContentType PrefsGetContentType();
        public UserGeoPermissions PrefsGetGeoPerms();
        public HiddenFromSearch PrefsGetHidden();
        public PrivacyFilter PrefsGetPrivacy();
        public SafetyLevel PrefsGetSafetyLevel();
        public Collection<PhotoInfoTag> TagsGetListPhoto(string photoId);
        public TagCollection TagsGetListUser();
        public TagCollection TagsGetListUser(string userId);
        public TagCollection TagsGetListUserPopular();
        public TagCollection TagsGetListUserPopular(int count);
        public TagCollection TagsGetListUserPopular(string userId);
        public TagCollection TagsGetListUserPopular(string userId, int count);
        public RawTagCollection TagsGetListUserRaw();
        public RawTagCollection TagsGetListUserRaw(string tag);
        public TagCollection TagsGetRelated(string tag);
        public ClusterCollection TagsGetClusters(string tag);
        public PhotoCollection TagsGetClusterPhotos(Cluster cluster);
        public PhotoCollection TagsGetClusterPhotos(Cluster cluster, PhotoSearchExtras extras);
        public PhotoCollection TagsGetClusterPhotos(string tag, string clusterId, PhotoSearchExtras extras);
        public HotTagCollection TagsGetHotList();
        public HotTagCollection TagsGetHotList(string period, int count);
        public string UrlsGetGroup(string groupId);
        public string UrlsGetUserPhotos();
        public string UrlsGetUserPhotos(string userId);
        public string UrlsGetUserProfile();
        public string UrlsGetUserProfile(string userId);
        public Gallery UrlsLookupGallery(string url);
        public string UrlsLookupGroup(string urlToFind);
        public FoundUser UrlsLookupUser(string urlToFind);
        public static void FlushCache();
        public static void FlushCache(string url);
        public static void FlushCache(Uri url);
        public Uri CalculateUri(Dictionary<string, string> parameters, bool includeSignature);
        public string AuthGetFrob();
        public string AuthCalcUrl(string frob, AuthLevel authLevel);
        public string AuthCalcWebUrl(AuthLevel authLevel);
        public string AuthCalcMobileUrl(AuthLevel authLevel);
        public Auth AuthGetToken(string frob);
        public Auth AuthGetFullToken(string miniToken);
        public Auth AuthCheckToken();
        public Auth AuthCheckToken(string token);
        public CollectionInfo CollectionsGetInfo(string collectionId);
        public CollectionCollection CollectionsGetTree();
        public CollectionCollection CollectionsGetTree(string collectionId, string userId);
        public string[] PandaGetList();
        public PandaPhotoCollection PandaGetPhotos(string pandaName);
        public PandaPhotoCollection PandaGetPhotos(string pandaName, PhotoSearchExtras extras);
        public PandaPhotoCollection PandaGetPhotos(string pandaName, int page, int perPage);
        public PandaPhotoCollection PandaGetPhotos(string pandaName, PhotoSearchExtras extras, int page, int perPage);
        public FoundUser PeopleFindByEmail(string emailAddress);
        public FoundUser PeopleFindByUserName(string userName);
        public Person PeopleGetInfo(string userId);
        public UserStatus PeopleGetUploadStatus();
        public PublicGroupInfoCollection PeopleGetPublicGroups(string userId);
        public PhotoCollection PeopleGetPublicPhotos(string userId);
        public PhotoCollection PeopleGetPublicPhotos(string userId, int page, int perPage);

        public PhotoCollection PeopleGetPublicPhotos(string userId, int page, int perPage, SafetyLevel safetyLevel,
                                                     PhotoSearchExtras extras);

        public PhotoCollection PeopleGetPhotos();
        public PhotoCollection PeopleGetPhotos(int page, int perPage);
        public PhotoCollection PeopleGetPhotos(PhotoSearchExtras extras);
        public PhotoCollection PeopleGetPhotos(PhotoSearchExtras extras, int page, int perPage);
        public PhotoCollection PeopleGetPhotos(string userId);
        public PhotoCollection PeopleGetPhotos(string userId, int page, int perPage);
        public PhotoCollection PeopleGetPhotos(string userId, PhotoSearchExtras extras);
        public PhotoCollection PeopleGetPhotos(string userId, PhotoSearchExtras extras, int page, int perPage);

        public PhotoCollection PeopleGetPhotos(string userId, SafetyLevel safeSearch, DateTime minUploadDate,
                                               DateTime maxUploadDate, DateTime minTakenDate, DateTime maxTakenDate,
                                               ContentTypeSearch contentType, PrivacyFilter privacyFilter,
                                               PhotoSearchExtras extras, int page, int perPage);

        public PeoplePhotoCollection PeopleGetPhotosOf();
        public PeoplePhotoCollection PeopleGetPhotosOf(string userId);
        public PeoplePhotoCollection PeopleGetPhotosOf(string userId, PhotoSearchExtras extras);
        public PeoplePhotoCollection PeopleGetPhotosOf(string userId, int page, int perPage);
        public PeoplePhotoCollection PeopleGetPhotosOf(string userId, PhotoSearchExtras extras, int page, int perPage);
        public void PhotosAddTags(string photoId, string[] tags);
        public void PhotosAddTags(string photoId, string tags);
        public void PhotosDelete(string photoId);
        public AllContexts PhotosGetAllContexts(string photoId);
        public PhotoCollection PhotosGetContactsPhotos();
        public PhotoCollection PhotosGetContactsPhotos(int count);

        public PhotoCollection PhotosGetContactsPhotos(int count, bool justFriends, bool singlePhoto, bool includeSelf,
                                                       PhotoSearchExtras extras);

        public PhotoCollection PhotosGetContactsPublicPhotos(string userId);
        public PhotoCollection PhotosGetContactsPublicPhotos(string userId, PhotoSearchExtras extras);
        public PhotoCollection PhotosGetContactsPublicPhotos(string userId, int count);
        public PhotoCollection PhotosGetContactsPublicPhotos(string userId, int count, PhotoSearchExtras extras);

        public PhotoCollection PhotosGetContactsPublicPhotos(string userId, int count, bool justFriends,
                                                             bool singlePhoto, bool includeSelf);

        public PhotoCollection PhotosGetContactsPublicPhotos(string userId, int count, bool justFriends,
                                                             bool singlePhoto, bool includeSelf,
                                                             PhotoSearchExtras extras);

        public Context PhotosGetContext(string photoId);
        public PhotoCountCollection PhotosGetCounts(DateTime[] dates);
        public PhotoCountCollection PhotosGetCounts(DateTime[] dates, bool taken);
        public PhotoCountCollection PhotosGetCounts(DateTime[] dates, DateTime[] takenDates);
        public ExifTagCollection PhotosGetExif(string photoId);
        public ExifTagCollection PhotosGetExif(string photoId, string secret);
        public PhotoInfo PhotosGetInfo(string photoId);
        public PhotoInfo PhotosGetInfo(string photoId, string secret);
        public PhotoPermissions PhotosGetPerms(string photoId);
        public PhotoCollection PhotosGetRecent();
        public PhotoCollection PhotosGetRecent(PhotoSearchExtras extras);
        public PhotoCollection PhotosGetRecent(int page, int perPage);
        public PhotoCollection PhotosGetRecent(int page, int perPage, PhotoSearchExtras extras);
        public SizeCollection PhotosGetSizes(string photoId);
        public PhotoCollection PhotosGetUntagged();
        public PhotoCollection PhotosGetUntagged(PhotoSearchExtras extras);
        public PhotoCollection PhotosGetUntagged(int page, int perPage);
        public PhotoCollection PhotosGetUntagged(int page, int perPage, PhotoSearchExtras extras);
        public PhotoCollection PhotosGetUntagged(PartialSearchOptions options);
        public PhotoCollection PhotosGetNotInSet();
        public PhotoCollection PhotosGetNotInSet(int page);
        public PhotoCollection PhotosGetNotInSet(int page, int perPage);
        public PhotoCollection PhotosGetNotInSet(int page, int perPage, PhotoSearchExtras extras);
        public PhotoCollection PhotosGetNotInSet(PartialSearchOptions options);
        public LicenseCollection PhotosLicensesGetInfo();
        public void PhotosLicensesSetLicense(string photoId, LicenseType license);
        public void PhotosRemoveTag(string tagId);
        public PhotoCollection PhotosRecentlyUpdated(DateTime minDate, PhotoSearchExtras extras);
        public PhotoCollection PhotosRecentlyUpdated(DateTime minDate, int page, int perPage);
        public PhotoCollection PhotosRecentlyUpdated(DateTime minDate);
        public PhotoCollection PhotosRecentlyUpdated(DateTime minDate, PhotoSearchExtras extras, int page, int perPage);
        public PhotoCollection PhotosSearch(PhotoSearchOptions options);
        public void PhotosSetDates(string photoId, DateTime dateTaken, DateGranularity granularity);
        public void PhotosSetDates(string photoId, DateTime datePosted);
        public void PhotosSetDates(string photoId, DateTime datePosted, DateTime dateTaken, DateGranularity granularity);
        public void PhotosSetMeta(string photoId, string title, string description);

        public void PhotosSetPerms(string photoId, int isPublic, int isFriend, int isFamily,
                                   PermissionComment permComment, PermissionAddMeta permAddMeta);

        public void PhotosSetPerms(string photoId, bool isPublic, bool isFriend, bool isFamily,
                                   PermissionComment permComment, PermissionAddMeta permAddMeta);

        public void PhotosSetTags(string photoId, string[] tags);
        public void PhotosSetTags(string photoId, string tags);
        public void PhotosSetContentType(string photoId, ContentType contentType);
        public void PhotosSetSafetyLevel(string photoId, HiddenFromSearch hidden);
        public void PhotosSetSafetyLevel(string photoId, SafetyLevel safetyLevel);
        public void PhotosSetSafetyLevel(string photoId, SafetyLevel safetyLevel, HiddenFromSearch hidden);
        public PhotoFavoriteCollection PhotosGetFavorites(string photoId);
        public PhotoFavoriteCollection PhotosGetFavorites(string photoId, int perPage, int page);
        public PlaceCollection PlacesFind(string query);
        public Place PlacesFindByLatLon(double latitude, double longitude);
        public Place PlacesFindByLatLon(double latitude, double longitude, GeoAccuracy accuracy);
        public PlaceCollection PlacesGetChildrenWithPhotosPublic(string placeId, string woeId);
        public PlaceInfo PlacesGetInfo(string placeId, string woeId);
        public PlaceInfo PlacesGetInfoByUrl(string url);
        public Dictionary<int, string> PlacesGetPlaceTypes();
        public ShapeDataCollection PlacesGetShapeHistory(string placeId, string woeId);
        public PlaceCollection PlacesGetTopPlacesList(PlaceType placeType);
        public PlaceCollection PlacesGetTopPlacesList(PlaceType placeType, string placeId, string woeId);
        public PlaceCollection PlacesGetTopPlacesList(PlaceType placeType, DateTime date);
        public PlaceCollection PlacesGetTopPlacesList(PlaceType placeType, DateTime date, string placeId, string woeId);
        public PlaceCollection PlacesPlacesForUser();
        public PlaceCollection PlacesPlacesForUser(PlaceType placeType, string woeId, string placeId);

        public PlaceCollection PlacesPlacesForUser(PlaceType placeType, string woeId, string placeId, int threshold,
                                                   DateTime minUploadDate, DateTime maxUploadDate, DateTime minTakenDate,
                                                   DateTime maxTakenDate);

        public PlaceCollection PlacesPlacesForTags(PlaceType placeType, string woeId, string placeId, int threshold,
                                                   string[] tags, TagMode tagMode, string[] machineTags,
                                                   MachineTagMode machineTagMode, DateTime minUploadDate,
                                                   DateTime maxUploadDate, DateTime minTakenDate, DateTime maxTakenDate);

        public PlaceCollection PlacesPlacesForContacts(PlaceType placeType, string woeId, string placeId, int threshold,
                                                       ContactSearch contactType, DateTime minUploadDate,
                                                       DateTime maxUploadDate, DateTime minTakenDate,
                                                       DateTime maxTakenDate);

        public PlaceCollection PlacesPlacesForBoundingBox(PlaceType placeType, string woeId, string placeId,
                                                          BoundaryBox boundaryBox);

        [Obsolete("This method is deprecated. Please use Flickr.PlacesGetInfo instead.")]
        public PlaceInfo PlacesResolvePlaceId(string placeId);

        [Obsolete("This method is deprecated. Please use Flickr.PlacesGetInfoByUrl instead.")]
        public PlaceInfo PlacesResolvePlaceUrl(string url);

        public TagCollection PlacesTagsForPlace(string placeId, string woeId);

        public TagCollection PlacesTagsForPlace(string placeId, string woeId, DateTime minUploadDate,
                                                DateTime maxUploadDate, DateTime minTakenDate, DateTime maxTakenDate);

        public MethodCollection ReflectionGetMethods();
        public Method ReflectionGetMethodInfo(string methodName);
        public StatDomainCollection StatsGetCollectionDomains(DateTime date);
        public StatDomainCollection StatsGetCollectionDomains(DateTime date, string collectionId);
        public StatDomainCollection StatsGetCollectionDomains(DateTime date, int page, int perPage);
        public StatDomainCollection StatsGetCollectionDomains(DateTime date, string collectionId, int page, int perPage);
        public CsvFileCollection StatsGetCsvFiles();
        public StatDomainCollection StatsGetPhotoDomains(DateTime date);
        public StatDomainCollection StatsGetPhotoDomains(DateTime date, string photoId);
        public StatDomainCollection StatsGetPhotoDomains(DateTime date, int page, int perPage);
        public StatDomainCollection StatsGetPhotoDomains(DateTime date, string photoId, int page, int perPage);
        public StatDomainCollection StatsGetPhotostreamDomains(DateTime date);
        public StatDomainCollection StatsGetPhotostreamDomains(DateTime date, int page, int perPage);
        public StatDomainCollection StatsGetPhotosetDomains(DateTime date);
        public StatDomainCollection StatsGetPhotosetDomains(DateTime date, string photosetId);
        public StatDomainCollection StatsGetPhotosetDomains(DateTime date, int page, int perPage);
        public StatDomainCollection StatsGetPhotosetDomains(DateTime date, string photosetId, int page, int perPage);
        public Stats StatsGetCollectionStats(DateTime date, string collectionId);
        public Stats StatsGetPhotoStats(DateTime date, string photoId);
        public Stats StatsGetPhotostreamStats(DateTime date);
        public Stats StatsGetPhotosetStats(DateTime date, string photosetId);
        public StatReferrerCollection StatsGetPhotoReferrers(DateTime date, string domain);
        public StatReferrerCollection StatsGetPhotoReferrers(DateTime date, string domain, string photoId);
        public StatReferrerCollection StatsGetPhotoReferrers(DateTime date, string domain, int page, int perPage);

        public StatReferrerCollection StatsGetPhotoReferrers(DateTime date, string domain, string photoId, int page,
                                                             int perPage);

        public StatReferrerCollection StatsGetPhotosetReferrers(DateTime date, string domain);
        public StatReferrerCollection StatsGetPhotosetReferrers(DateTime date, string domain, string photosetId);
        public StatReferrerCollection StatsGetPhotosetReferrers(DateTime date, string domain, int page, int perPage);

        public StatReferrerCollection StatsGetPhotosetReferrers(DateTime date, string domain, string photosetId,
                                                                int page, int perPage);

        public StatReferrerCollection StatsGetCollectionReferrers(DateTime date, string domain);
        public StatReferrerCollection StatsGetCollectionReferrers(DateTime date, string domain, string collectionId);
        public StatReferrerCollection StatsGetCollectionReferrers(DateTime date, string domain, int page, int perPage);

        public StatReferrerCollection StatsGetCollectionReferrers(DateTime date, string domain, string collectionId,
                                                                  int page, int perPage);

        public StatReferrerCollection StatsGetPhotostreamReferrers(DateTime date, string domain);
        public StatReferrerCollection StatsGetPhotostreamReferrers(DateTime date, string domain, int page, int perPage);
        public StatViews StatsGetTotalViews();
        public StatViews StatsGetTotalViews(DateTime date);
        public PopularPhotoCollection StatsGetPopularPhotos();
        public PopularPhotoCollection StatsGetPopularPhotos(DateTime date);
        public PopularPhotoCollection StatsGetPopularPhotos(PopularitySort sort);
        public PopularPhotoCollection StatsGetPopularPhotos(PopularitySort sort, int page, int perPage);
        public PopularPhotoCollection StatsGetPopularPhotos(DateTime date, int page, int perPage);
        public PopularPhotoCollection StatsGetPopularPhotos(DateTime date, PopularitySort sort, int page, int perPage);
        public UnknownResponse TestGeneric(string method, Dictionary<string, string> parameters);
        public FoundUser TestLogin();
        public void TestNull();
        public EchoResponseDictionary TestEcho(Dictionary<string, string> parameters);
        public event EventHandler<UploadProgressEventArgs> OnUploadProgress;
    }
}
