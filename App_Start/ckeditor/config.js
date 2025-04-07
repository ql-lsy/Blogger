/**
 * @license Copyright (c) 2003-2023, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
	config.image_previewText = ' '; //情空预览区域显示内容
	config.removeDialogTabs = 'image:advanced;image:Link;', 'help';
	config.filebrowserImageUploadUrl = "/Upload/Upload"; //待会要上传的action或servlet
	config.imageUploadUrl = "/jjfp/home/home_imgUpload.action"; 	//粘贴图片上传的action或servlet
	config.toolbarGroups = [
		{ name: 'document', groups: ['mode', 'document', 'doctools'] },
		{ name: 'clipboard', groups: ['clipboard', 'undo'] },
		{ name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
		{ name: 'forms', groups: ['forms'] },
		'/',
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
		{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
		{ name: 'links', groups: ['links'] },
		{ name: 'insert', groups: ['insert'] },
		'/',
		{ name: 'styles', groups: ['styles'] },
		{ name: 'colors', groups: ['colors'] },
		{ name: 'tools', groups: ['tools'] },
		{ name: 'others', groups: ['others'] },
		{ name: 'about', groups: ['about'] }
	];

	config.removeButtons = 'Copy,Paste,Undo,Redo,Anchor,Underline,Strike,Subscript,Superscript,Source,Cut,ImageButton,Button,HiddenField,Radio,Checkbox,CreateDiv,Unlink,Flash,Iframe,About,ShowBlocks,NewPage,Templates';

	config.removeDialogTabs = 'image:advanced;link:advanced';

};